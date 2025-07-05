using BusinessObjects;
using HivTreatmentAppWPF.Manager; 
using System.Windows;

namespace HivTreatmentAppWPF
{
    public partial class ManagerWindow : Window
    {
        private readonly User _user;

        public ManagerWindow(User user)
        {
            InitializeComponent();

            _user = user;

            txtGreeting.Text = $"Chào mừng quản lí {_user.FullName}";

            frMain.Navigate(new ManagerSchedulePage());
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
