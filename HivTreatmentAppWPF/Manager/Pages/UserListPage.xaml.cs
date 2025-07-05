using BusinessObjects;
using DataAccessLayer;
using HivTreatmentAppWPF.Manager.Components;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HivTreatmentAppWPF.Manager
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? AccountStatus { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long? RoleId { get; set; }
        public string? RoleName { get; set; }
    }

    public partial class UserListPage : Page
    {
        private List<UserDTO> _allUsers = new();
        private ObservableCollection<UserDTO> _displayedUsers = new();
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly HivDbContext hivDbContext = new();

        public UserListPage()
        {
            InitializeComponent();

            var userRepository = new UserRepository(hivDbContext);
            var roleRepository = new RoleRepository(hivDbContext);
            userService = new UserService(userRepository, roleRepository);
            roleService = new RoleService(roleRepository);

            LoadUsers();
        }

        private void LoadUsers()
        {
            var userList = userService.GetAll();
            _allUsers = userList.Select(u => new UserDTO
            {
                Id = u.Id,
                FullName = u.FullName,
                Address = u.Address,
                Gender = u.Gender,
                AccountStatus = u.AccountStatus,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,
                Username = u.Username,
                Password = u.Password,
                DateOfBirth = u.DateOfBirth,
                RoleId = u.RoleId,
                RoleName = hivDbContext.Roles.FirstOrDefault(r => r.Id == u.RoleId)?.RoleName ?? "(Không có)"
            }).ToList();

            _displayedUsers = new ObservableCollection<UserDTO>(_allUsers);
            UserDataGrid.ItemsSource = _displayedUsers;
        }

        private void ApplyFilter()
        {
            if (SearchBox == null)
                return;

            string keyword = SearchBox.Text?.Trim().ToLower() ?? "";

            var filtered = _allUsers.Where(u =>
                (u.FullName ?? "").ToLower().Contains(keyword)
                || (u.Email ?? "").ToLower().Contains(keyword)
                || (u.PhoneNumber ?? "").ToLower().Contains(keyword)
            ).ToList();

            _displayedUsers.Clear();
            foreach (var user in filtered)
            {
                _displayedUsers.Add(user);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new UserEditDialog();

            if (dialog.ShowDialog() == true)
            {
                var result = dialog.UserData;

                var newUser = new User
                {
                    FullName = result.FullName,
                    Address = result.Address,
                    Gender = result.Gender,
                    AccountStatus = result.AccountStatus,
                    PhoneNumber = result.PhoneNumber,
                    Email = result.Email,
                    Username = result.Username,
                    Password = result.Password,
                    DateOfBirth = result.DateOfBirth,
                    RoleId = result.RoleId
                };

                userService.Add(newUser);
                LoadUsers();
                MessageBox.Show("Đã thêm người dùng mới.");
            }
        }

        private void UserDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (UserDataGrid.SelectedItem is not UserDTO selectedDto)
            {
                MessageBox.Show("Vui lòng chọn người dùng để sửa.");
                return;
            }

            var user = userService.GetById(selectedDto.Id);
            if (user == null)
            {
                MessageBox.Show("Người dùng không tồn tại.");
                return;
            }

            var dialog = new UserEditDialog(user);

            if (dialog.ShowDialog() != true) return;

            var updatedUser = dialog.UserData;

            user.FullName = updatedUser.FullName;
            user.Address = updatedUser.Address;
            user.Gender = updatedUser.Gender;
            user.AccountStatus = updatedUser.AccountStatus;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Email = updatedUser.Email;
            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password;
            user.DateOfBirth = updatedUser.DateOfBirth;
            user.RoleId = updatedUser.RoleId;

            userService.Update(user);
            LoadUsers();
            MessageBox.Show("Đã cập nhật người dùng.");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedItem is not UserDTO selectedDto)
            {
                MessageBox.Show("Vui lòng chọn người dùng để xoá.");
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa người dùng này?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirm != MessageBoxResult.Yes) return;

            userService.Delete(selectedDto.Id);
            LoadUsers();
            MessageBox.Show("Đã xoá người dùng.");
        }
    }
}
