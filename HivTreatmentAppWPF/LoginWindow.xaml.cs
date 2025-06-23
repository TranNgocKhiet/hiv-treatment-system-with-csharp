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
            var userService = new UserService(userRepository);
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
                    //ManagerWindow managerWindow = new ManagerWindow(user);
                    //managerWindow.Show();
                }
                else if (user.RoleId == 2) {
                    this.Hide();
                    //DoctorWindow doctorWindow = new DoctorWindow(user);
                    //doctorWindow.Show();
                }
                else if (user.RoleId == 3)
                {
                    this.Hide();
                    //PatientWindow patientWindow = new PatientWindow(user);
                    //patientWindow.Show();
                }
            }
            else
            {
                MessageBox.Show("You are not permission !");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
