using BusinessObjects;
using DataAccessLayer;
using HivTreatmentAppWPF;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System.Windows;

namespace HivTreatmentAppWPF
{
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;
        public LoginWindow()
        {
            InitializeComponent();

            var context = new HivDbContext();
            var userRepository = UserRepository.GetInstance(context);
            var roleRepository = new RoleRepository(context);
            var userService = new UserService(userRepository, roleRepository);
            _userService = userService;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Password;

            User user = _userService.Login(username, password);
            if (user != null) 
            { 
                if (user.RoleId == 1)
                {
                    this.Hide();
                    ManagerWindow managerWindow = new ManagerWindow(user);
                    managerWindow.Show();
                }
                else if (user.RoleId == 2) {
                    this.Hide();
                    DoctorWindow doctorWindow = new DoctorWindow(user);
                    doctorWindow.Show();
                }
                else if (user.RoleId == 3)
                {
                    this.Hide();
                    LabTechnicianWindow labTechnicianWindow = new LabTechnicianWindow(user);
                    labTechnicianWindow.Show();
                }
                else if (user.RoleId == 4)
                {
                    this.Hide();
                    PatientWindow patientWindow = new PatientWindow(user);
                    patientWindow.Show();
                }
            }
            else
            {
                MessageBox.Show("You are not permission !");
            }
        }
        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPasswordVisible.Text = txtPassword.Password;
            txtPasswordVisible.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = txtPasswordVisible.Text;
            txtPasswordVisible.Visibility = Visibility.Collapsed;
            txtPassword.Visibility = Visibility.Visible;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!chkShowPassword.IsChecked ?? false)
                return;

            txtPasswordVisible.Text = txtPassword.Password;
        }

        private void txtPasswordVisible_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (chkShowPassword.IsChecked ?? false)
            {
                txtPassword.Password = txtPasswordVisible.Text;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
