using BusinessObjects;
using System.Collections.ObjectModel;
using System.Windows;

namespace HivTreatmentAppWPF.Doctor
{
    public partial class TestResultAddWindow : Window
    {
        public ObservableCollection<TestResult> TestResultEntries { get; } = new();

        public List<TestResult> Results { get; private set; } = new();

        public TestResultAddWindow()
        {
            InitializeComponent();
            TestResultEntries.Add(new TestResult());
            TestResultList.ItemsSource = TestResultEntries;
        }

        private void AddTestResult_Click(object sender, RoutedEventArgs e)
        {
            TestResultEntries.Add(new TestResult());
        }

        private void RemoveTestResult_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is TestResult toRemove)
            {
                TestResultEntries.Remove(toRemove);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var validResults = TestResultEntries
                .Where(t => !string.IsNullOrWhiteSpace(t.Type))
                .Select(t => new TestResult
                {
                    Type = t.Type,
                    Unit = "",
                    Result = "",
                    Note = "",
                    ExpectedResultTime = null,
                    ActualResultTime = null
                }).ToList();

            if (validResults.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất một loại xét nghiệm hợp lệ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Results = validResults;
            DialogResult = true;
            Close();
        }
    }
}
