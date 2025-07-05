using BusinessObjects;
using HivTreatmentAppWPF;
using HivTreatmentAppWPF.LabTechnician.Pages;
using System.DirectoryServices.ActiveDirectory;
using System.Windows;

namespace HivTreatmentAppWPF
{
    public partial class LabTechnicianWindow : Window
    {
        private readonly User _user;

        public LabTechnicianWindow(User user)
        {
            InitializeComponent();

            _user = user;

            txtGreeting.Text = $"Chào mừng kỹ thuật viên {_user.FullName}";

            frMain.Navigate(new HealthRecordListPage());
        }

        private void ToHealthRecordListPageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new HealthRecordListPage());
        }

        private void ToEditProfilePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new LabTechnicianProfileEditPage(_user));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
