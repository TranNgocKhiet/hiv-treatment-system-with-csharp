using BusinessObjects;
using HivTreatmentAppWPF.Patient;
using System.Windows;

namespace HivTreatmentAppWPF
{
    public partial class PatientWindow : Window
    {
        private User _user;
        public PatientWindow(User user)
        {
            InitializeComponent();

            _user = user;

            txtGreeting.Text = $"Chào mừng bạn {_user.FullName}";

            frMain.Navigate(new UserScheduleRegisterPage(_user));
        }

        private void ToSchedulePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new UserScheduleRegisterPage(_user));
        }

        private void ToAppointmentHistoryPageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new UserSchedulePage(_user));
        }

        private void ToProfilePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new UserProfileEditPage(_user));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
