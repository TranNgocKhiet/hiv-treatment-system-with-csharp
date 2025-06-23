using System.Windows;
using HivTreatmentAppWPF.Manager; 

namespace HivTreatmentAppWPF
{
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void ToUserListPageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new UserListPage());
        }

        private void ToMangerSchedulePageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new ManagerSchedulePage());
        }

        private void ToRequestListPageButton_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new RequestListPage());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
