using BusinessObjects;
using System.Collections.ObjectModel;
using System.Windows;

namespace HivTreatmentAppWPF.Patient.Components
{
    public partial class HealthRecordViewWindow : Window
    {
        public HealthRecord HealthRecord { get; set; }
        public ObservableCollection<TestResult> TestResults { get; set; }
        public Regimen Regimen { get; set; }

        public HealthRecordViewWindow(HealthRecord record, List<TestResult> testResults, Regimen regimen)
        {
            InitializeComponent();
            HealthRecord = record;
            TestResults = new ObservableCollection<TestResult>(testResults);
            Regimen = regimen;

            DataContext = this;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
