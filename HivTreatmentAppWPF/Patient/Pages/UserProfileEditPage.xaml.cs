using BusinessObjects;
using DataAccessLayer;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HivTreatmentAppWPF.Patient
{
    public partial class UserProfileEditPage : Page
    {
        private readonly IUserService _userService;
        private readonly User _user;

        public UserProfileEditPage(User user)
        {
            InitializeComponent();
            _user = user;

            var context = new HivDbContext();
            var userRepo = UserRepository.GetInstance(context);
            var roleRepo = new RoleRepository(context);
            _userService = new UserService(userRepo, roleRepo);

            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            FullNameTextBox.Text = _user.FullName;
            AddressTextBox.Text = _user.Address;
            PhoneNumberTextBox.Text = _user.PhoneNumber;
            EmailTextBox.Text = _user.Email;
            UsernameTextBox.Text = _user.Username;
            PasswordBox.Password = _user.Password;
            DateOfBirthPicker.SelectedDate = _user.DateOfBirth;

            GenderComboBox.SelectedIndex = _user.Gender switch
            {
                "Nam" => 0,
                "Nữ" => 1,
                "Khác" => 2,
                _ => 0
            };
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _user.FullName = FullNameTextBox.Text;
            _user.Address = AddressTextBox.Text;
            _user.Gender = ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString();
            _user.PhoneNumber = PhoneNumberTextBox.Text;
            _user.Email = EmailTextBox.Text;
            _user.Password = PasswordBox.Password;
            _user.DateOfBirth = DateOfBirthPicker.SelectedDate;

            try
            {
                _userService.Update(_user);
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
