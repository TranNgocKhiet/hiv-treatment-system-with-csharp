using System.Windows;
using HivTreatmentAppWPF.Patient;

namespace HivTreatmentAppWPF
{
    public partial class PatientWindow : Window
    {
        public PatientWindow()
        {
            InitializeComponent();
        }

        private void ToUserSchedulePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new UserSchedulePage());
        }

        private void ToUserHistoryPageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new UserHistoryPage());
        }

        private void ToUserEditProfilePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new UserEditProfilePage());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
