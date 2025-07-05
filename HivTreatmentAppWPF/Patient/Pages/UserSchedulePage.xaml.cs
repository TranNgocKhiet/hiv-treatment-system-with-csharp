using BusinessObjects;
using DataAccessLayer;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HivTreatmentAppWPF.Patient.Components;

namespace HivTreatmentAppWPF.Patient
{
    public partial class UserSchedulePage : Page
    {
        private readonly IScheduleService _scheduleService;
        private readonly IUserService _userService;
        private readonly IHealthRecordService _hrService;
        private readonly ITestResultService _trService;
        private readonly IRegimenService _regimenService;
        private readonly User _user;
        private readonly HivDbContext _dbContext = new();

        // Danh sách lưu trữ toàn bộ
        private List<ScheduleDisplayDto> _allSchedules = new();
        // Danh sách để hiển thị
        private ObservableCollection<ScheduleDisplayDto> _displayedSchedules = new();

        public UserSchedulePage(User user)
        {
            InitializeComponent();

            _user = user;

            var scheduleRepo = new ScheduleRepository(_dbContext);
            _scheduleService = new ScheduleService(scheduleRepo);

            var userRepo = UserRepository.GetInstance(_dbContext);
            _userService = new UserService(userRepo, new RoleRepository(_dbContext));

            var regimenRepo = new RegimenRepository(_dbContext);
            _regimenService = new RegimenService(regimenRepo);

            _hrService = new HealthRecordService(new HealthRecordRepository(_dbContext));
            _trService = new TestResultService(new TestResultRepository(_dbContext));

            ScheduleDataGrid.MouseDoubleClick += ScheduleDataGrid_MouseDoubleClick;

            LoadPatientSchedules();
        }

        private class ScheduleDisplayDto
        {
            public long Id { get; set; }
            public string? RoomCode { get; set; }
            public DateTime? Date { get; set; }
            public string? Slot { get; set; }
            public string? Type { get; set; }
            public string? ActiveStatus { get; set; }
            public string? RequestStatus { get; set; }
            public string? DoctorName { get; set; }
        }

        private void LoadPatientSchedules()
        {
            var list = _scheduleService.GetAll()
                .Where(s => s.PatientId == _user.Id)
                .OrderByDescending(s => s.Date)
                .Select(s => new ScheduleDisplayDto
                {
                    Id = s.Id,
                    RoomCode = s.RoomCode,
                    Date = s.Date,
                    Slot = s.Slot?.ToString(@"hh\:mm"),
                    Type = s.Type,
                    ActiveStatus = s.ActiveStatus,
                    RequestStatus = s.RequestStatus,
                    DoctorName = s.DoctorId.HasValue
                        ? _userService.GetById(s.DoctorId.Value)?.FullName ?? "Không xác định"
                        : "Không xác định"
                })
                .ToList();

            _allSchedules = list;
            _displayedSchedules = new ObservableCollection<ScheduleDisplayDto>(_allSchedules);
            ScheduleDataGrid.ItemsSource = _displayedSchedules;
        }

        private void ApplyFilter()
        {
            if (SearchBox == null) return;

            string keyword = SearchBox.Text?.Trim().ToLower() ?? "";

            var filtered = _allSchedules
                .Where(s => (s.DoctorName ?? "").ToLower().Contains(keyword))
                .ToList();

            _displayedSchedules.Clear();
            foreach (var item in filtered)
                _displayedSchedules.Add(item);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void ScheduleDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ScheduleDataGrid.SelectedItem is not ScheduleDisplayDto selected)
                return;

            HealthRecord healthRecord = _hrService.GetById(selected.Id);
            if (healthRecord == null)
            {
                MessageBox.Show("Không tìm thấy hồ sơ sức khỏe.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            List<TestResult> testResults = _trService.GetByHealthRecordId(healthRecord.Id);
            Regimen regimen = _regimenService.GetById(healthRecord.RegimenId ?? 0);
            var detailWindow = new HealthRecordViewWindow(healthRecord, testResults, regimen);
            detailWindow.Owner = Window.GetWindow(this);
            detailWindow.ShowDialog();

            ScheduleDataGrid.SelectedItem = null;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleDataGrid.SelectedItem is not ScheduleDisplayDto sel)
            {
                MessageBox.Show("Vui lòng chọn lịch khám để hủy.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy lịch khám này?\nHành động này không thể hoàn tác.",
                "Xác nhận hủy lịch",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (confirm != MessageBoxResult.Yes)
                return;

            var schedule = _scheduleService.GetById(sel.Id);
            if (schedule == null)
            {
                MessageBox.Show("Không tìm thấy lịch khám.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            schedule.ActiveStatus = "Đã hủy";
            _scheduleService.Update(schedule);

            MessageBox.Show("Lịch khám đã được hủy.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            LoadPatientSchedules();
        }

    }
}
