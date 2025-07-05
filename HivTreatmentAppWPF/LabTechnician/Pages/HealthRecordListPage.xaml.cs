using BusinessObjects;
using DataAccessLayer;
using HivTreatmentAppWPF.LabTechnician.Components;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HivTreatmentAppWPF.LabTechnician.Pages
{
    public partial class HealthRecordListPage : Page
    {
        private readonly IUserService _userService;
        private readonly IHealthRecordService _hrService;
        private readonly IScheduleService _scheduleService;

        private List<PatientDisplayDto> _allPatients;

        private class PatientDisplayDto
        {
            public long HealthRecordId { get; set; }
            public string PatientName { get; set; }
            public DateTime? Date { get; set; }
            public string Slot { get; set; }
            public string RoomCode { get; set; }
        }

        public HealthRecordListPage()
        {
            InitializeComponent();

            var ctx = new HivDbContext();

            _userService = new UserService(new UserRepository(ctx), new RoleRepository(ctx));
            _hrService = new HealthRecordService(new HealthRecordRepository(ctx));
            _scheduleService = new ScheduleService(new ScheduleRepository(ctx));

            LoadPatients();
        }

        private void LoadPatients()
        {
            _allPatients = (from hr in _hrService.GetAll()
                            join sc in _scheduleService.GetAll() on hr.ScheduleId equals sc.Id
                            join u in _userService.GetAll() on sc.PatientId equals u.Id
                            where sc.PatientId != null
                            select new PatientDisplayDto
                            {
                                HealthRecordId = hr.Id,
                                PatientName = u.FullName,
                                Date = sc.Date,
                                Slot = sc.Slot?.ToString(@"hh\:mm"),
                                RoomCode = sc.RoomCode
                            })
                            .OrderBy(p => p.Date)
                            .ToList();

            PatientDataGrid.ItemsSource = _allPatients;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = SearchTextBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                PatientDataGrid.ItemsSource = _allPatients;
            }
            else
            {
                var filtered = _allPatients
                    .Where(p => p.PatientName != null && p.PatientName.ToLower().Contains(keyword))
                    .ToList();

                PatientDataGrid.ItemsSource = filtered;
            }
        }

        private void PatientDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PatientDataGrid.SelectedItem is not PatientDisplayDto selected) return;

            var ctx = new HivDbContext();

            var testResultService = new TestResultService(new TestResultRepository(ctx));
            List<TestResult> testResults = testResultService.GetAll()
                .Where(tr => tr.HealthRecordId == selected.HealthRecordId)
                .ToList();

            HealthRecord healthRecord = _hrService.GetById(selected.HealthRecordId);

            var editWindow = new EditTestResultWindow(testResults, healthRecord, _hrService, testResultService);
            editWindow.ShowDialog();

            LoadPatients();
        }
    }
}
