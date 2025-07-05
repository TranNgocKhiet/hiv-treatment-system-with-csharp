using System;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;
using DataAccessLayer;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;

namespace HivTreatmentAppWPF.LabTechnician.Pages
{
    public partial class LabTechnicianProfileEditPage : Page
    {
        private readonly IUserService _userService;
        private readonly User _currentUser;

        public LabTechnicianProfileEditPage(User user)
        {
            InitializeComponent();

            _currentUser = user;

            var context = new HivDbContext();
            var userRepo = UserRepository.GetInstance(context);
            var roleRepo = new RoleRepository(context);
            _userService = new UserService(userRepo, roleRepo);

            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            FullNameTextBox.Text = _currentUser.FullName;
            AddressTextBox.Text = _currentUser.Address;
            PhoneNumberTextBox.Text = _currentUser.PhoneNumber;
            EmailTextBox.Text = _currentUser.Email;
            UsernameTextBox.Text = _currentUser.Username;
            PasswordBox.Password = _currentUser.Password;
            DateOfBirthPicker.SelectedDate = _currentUser.DateOfBirth;

            GenderComboBox.SelectedIndex = _currentUser.Gender switch
            {
                "Nam" => 0,
                "Nữ" => 1,
                "Khác" => 2,
                _ => 0
            };
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _currentUser.FullName = FullNameTextBox.Text;
            _currentUser.Address = AddressTextBox.Text;
            _currentUser.Gender = ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString();
            _currentUser.PhoneNumber = PhoneNumberTextBox.Text;
            _currentUser.Email = EmailTextBox.Text;
            _currentUser.Password = PasswordBox.Password;
            _currentUser.DateOfBirth = DateOfBirthPicker.SelectedDate;

            try
            {
                _userService.Update(_currentUser);
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
