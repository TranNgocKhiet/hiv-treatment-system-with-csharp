using BusinessObjects;
using HivTreatmentAppWPF.Doctor;
using System.Windows;

namespace HivTreatmentAppWPF
{
    public partial class DoctorWindow : Window
    {
        private readonly User _user;
        public DoctorWindow(User user)
        {
            InitializeComponent();

            _user = user;

            txtGreeting.Text = $"Chào mừng bác sĩ {_user.FullName}";

            frMain.Navigate(new DoctorSchedulePage(_user));
        }

        private void ToRegimenListPageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new RegimenListPage(_user));
        }

        private void ToDoctorSchedulePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new DoctorSchedulePage(_user));
        }

        private void ToDoctorEditProfilePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new DoctorProfileEditPage(_user));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
