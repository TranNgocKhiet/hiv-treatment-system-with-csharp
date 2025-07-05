using BusinessObjects;
using System;
using System.Windows;
using System.Windows.Controls;
using Services.Interfaces;
using Services.Implementations;
using RepositoryLayer;
using DataAccessLayer;
using System.Linq;

namespace HivTreatmentAppWPF.Manager.Components
{
    public partial class UserEditDialog : Window
    {
        private readonly IRoleService roleService;
        private readonly HivDbContext dbContext = new HivDbContext();

        public User UserData { get; private set; }

        public UserEditDialog(User? user = null)
        {
            InitializeComponent();

            var roleRepo = new RoleRepository(dbContext);
            roleService = new RoleService(roleRepo);

            LoadRoles();

            if (user != null)
            {
                UserData = new User
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Address = user.Address,
                    Gender = user.Gender,
                    AccountStatus = user.AccountStatus,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Username = user.Username,
                    Password = user.Password,
                    DateOfBirth = user.DateOfBirth,
                    RoleId = user.RoleId
                };

                FullNameTextBox.Text = user.FullName;
                AddressTextBox.Text = user.Address;
                GenderComboBox.SelectedItem = GetComboBoxItemByContent(GenderComboBox, user.Gender);
                AccountStatusComboBox.SelectedItem = GetComboBoxItemByContent(AccountStatusComboBox, user.AccountStatus);
                PhoneNumberTextBox.Text = user.PhoneNumber;
                EmailTextBox.Text = user.Email;
                UsernameTextBox.Text = user.Username;
                PasswordBox.Password = user.Password;
                DateOfBirthPicker.SelectedDate = user.DateOfBirth;
                RoleComboBox.SelectedValue = user.RoleId;
            }
            else
            {
                UserData = new User();
                GenderComboBox.SelectedIndex = 0;
                AccountStatusComboBox.SelectedIndex = 0;
            }
        }

        private void LoadRoles()
        {
            var roles = roleService.GetAll();
            RoleComboBox.ItemsSource = roles;
            RoleComboBox.DisplayMemberPath = "RoleName";
            RoleComboBox.SelectedValuePath = "Id";
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoleComboBox.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò.");
                return;
            }

            UserData.FullName = FullNameTextBox.Text;
            UserData.Address = AddressTextBox.Text;
            UserData.Gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            UserData.AccountStatus = (AccountStatusComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            UserData.PhoneNumber = PhoneNumberTextBox.Text;
            UserData.Email = EmailTextBox.Text;
            UserData.Username = UsernameTextBox.Text;
            UserData.Password = PasswordBox.Password;
            UserData.DateOfBirth = DateOfBirthPicker.SelectedDate;
            UserData.RoleId = (long)RoleComboBox.SelectedValue;

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private ComboBoxItem? GetComboBoxItemByContent(ComboBox comboBox, string? content)
        {
            foreach (ComboBoxItem item in comboBox.Items)
            {
                if (item.Content?.ToString() == content)
                    return item;
            }
            return null;
        }
    }
}
