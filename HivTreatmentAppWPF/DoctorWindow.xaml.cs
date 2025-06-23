using System.Windows;
using HivTreatmentAppWPF.Doctor;

namespace HivTreatmentAppWPF
{
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
        }

        private void ToRegimenListPageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new RegimenListPage());
        }

        private void ToDoctorSchedulePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new DoctorSchedulePage());
        }

        private void ToDoctorEditProfilePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new DoctorEditProfilePage());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
