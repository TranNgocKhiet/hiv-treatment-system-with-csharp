using BusinessObjects;
using DataAccessLayer;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace HivTreatmentAppWPF.Doctor
{
    public partial class HealthRecordEditWindow : Window
    {
        private readonly HivDbContext _context = new();
        private readonly IHealthRecordService _hrService;
        private readonly ITestResultService _trService;
        private readonly IRegimenService _regimenService;
        private readonly List<TestResult> _deletedTests = new();
        private readonly User _currentUser;

        private class HealthRecordDetailVm : INotifyPropertyChanged
        {
            public HealthRecord HealthRecord { get; init; } = null!;
            public ObservableCollection<TestResult> TestResults { get; init; } = null!;
            public ObservableCollection<Regimen> Regimens { get; init; } = null!;

            private Regimen? _selectedRegimen;
            public Regimen? SelectedRegimen
            {
                get => _selectedRegimen;
                set
                {
                    if (_selectedRegimen != value)
                    {
                        _selectedRegimen = value;
                        OnPropertyChanged(nameof(SelectedRegimen));
                    }
                }
            }

            public event PropertyChangedEventHandler? PropertyChanged;
            private void OnPropertyChanged(string name) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private readonly HealthRecord _originRecord;
        private readonly HealthRecordDetailVm _vm;

        public HealthRecordEditWindow(HealthRecord record, User user)
        {
            InitializeComponent();

            _currentUser = user;

            _hrService = new HealthRecordService(new HealthRecordRepository(_context));
            _trService = new TestResultService(new TestResultRepository(_context));
            _regimenService = new RegimenService(new RegimenRepository(_context));

            _originRecord = record;

            var editableCopy = new HealthRecord
            {
                Id = record.Id,
                HivStatus = record.HivStatus,
                BloodType = record.BloodType,
                TreatmentStatus = record.TreatmentStatus,
                Weight = record.Weight,
                Height = record.Height,
                ScheduleId = record.ScheduleId,
                RegimenId = record.RegimenId
            };

            var testList = _trService.GetByHealthRecordId(record.Id);

            var regimens = _regimenService.GetByDoctorIdAndNull(user.Id);

            _vm = new HealthRecordDetailVm
            {
                HealthRecord = editableCopy,
                TestResults = new ObservableCollection<TestResult>(testList),
                Regimens = new ObservableCollection<Regimen>(regimens)
            };

            DataContext = _vm;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _originRecord.HivStatus = _vm.HealthRecord.HivStatus;
            _originRecord.BloodType = _vm.HealthRecord.BloodType;
            _originRecord.TreatmentStatus = _vm.HealthRecord.TreatmentStatus;
            _originRecord.Weight = _vm.HealthRecord.Weight;
            _originRecord.Height = _vm.HealthRecord.Height;

            try
            {
                _hrService.Update(_originRecord);

                foreach (var test in _vm.TestResults)
                {
                    test.HealthRecordId = _originRecord.Id;

                    if (test.Id == 0)
                        _trService.Add(test);
                    else
                        _trService.Update(test);
                }

                foreach (var del in _deletedTests)
                    _trService.Delete(del.Id);

                _deletedTests.Clear();

                MessageBox.Show("Lưu thành công!", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        private void DeleteTestResult_Click(object sender, RoutedEventArgs e)
        {
            if (TestResultDataGrid.SelectedItem is TestResult selected)
            {
                var result = MessageBox.Show("Xác nhận xóa kết quả xét nghiệm?", "Xác nhận", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (selected.Id != 0) _deletedTests.Add(selected);
                    _vm.TestResults.Remove(selected);
                }
            }
        }

        private void RegimenSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = RegimenSearchBox.Text.Trim().ToLower();

            var filtered = _regimenService
                .GetByDoctorIdAndNull(_currentUser.Id)
                .Where(r =>
                    (!string.IsNullOrEmpty(r.RegimenName) && r.RegimenName.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(r.Components) && r.Components.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(r.Contraindications) && r.Contraindications.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(r.Indications) && r.Indications.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(r.Description) && r.Description.ToLower().Contains(keyword)))
                .ToList();

            _vm.Regimens.Clear();
            foreach (var r in filtered)
                _vm.Regimens.Add(r);
        }

        public Regimen SelectedRegimen { get; set; }

        private void RegimenComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RegimenComboBox.SelectedValue is long id)
                _vm.SelectedRegimen = _vm.Regimens.FirstOrDefault(r => r.Id == id);
        }

        private void AddTestResult_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new TestResultAddWindow();
            if (addWindow.ShowDialog() == true)
            {
                foreach (var result in addWindow.Results)
                {
                    result.HealthRecordId = _originRecord.Id;
                    _vm.TestResults.Add(result);
                }
            }
        }
    }
}
