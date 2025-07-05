using BusinessObjects;
using DataAccessLayer;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HivTreatmentAppWPF.Doctor
{
    public partial class DoctorSchedulePage : Page
    {
        private readonly IScheduleService _scheduleService;
        private readonly IUserService _userService;
        private readonly IHealthRecordService _healthRecordService;
        private readonly User _currentUser;

        private List<DoctorScheduleDisplayDto> _allSchedules;

        public DoctorSchedulePage(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            var context = new HivDbContext();
            _scheduleService = new ScheduleService(new ScheduleRepository(context));
            _userService = new UserService(new UserRepository(context), new RoleRepository(context));
            _healthRecordService = new HealthRecordService(new HealthRecordRepository(context));

            LoadSchedule();
        }

        private class DoctorScheduleDisplayDto
        {
            public long ScheduleId { get; set; }
            public long? PatientId { get; set; }
            public string RoomCode { get; set; } = "";
            public DateTime? Date { get; set; }
            public string Slot { get; set; } = "";
            public string PatientName { get; set; } = "";
            public string TreatmentStatus { get; set; } = "";
        }

        private void LoadSchedule()
        {
            _allSchedules = _scheduleService.GetAll()
                .Where(s => s.DoctorId == _currentUser.Id
                         && s.ActiveStatus == "Đang hoạt động"
                         && s.RequestStatus == "Đã duyệt")
                .OrderBy(s => s.Date)
                .ThenBy(s => s.Slot)
                .Select(s => new DoctorScheduleDisplayDto
                {
                    ScheduleId = s.Id,
                    PatientId = s.PatientId,
                    RoomCode = s.RoomCode,
                    Date = s.Date,
                    Slot = s.Slot?.ToString(@"hh\:mm"),
                    PatientName = s.PatientId.HasValue
                        ? _userService.GetById(s.PatientId.Value)?.FullName ?? "Không xác định"
                        : "Không xác định",
                    TreatmentStatus = _healthRecordService.GetByScheduleId(s.Id)?.TreatmentStatus ?? "(Chưa có)"
                })
                .ToList();

            ScheduleDataGrid.ItemsSource = _allSchedules;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchTextBox.Text?.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                ScheduleDataGrid.ItemsSource = _allSchedules;
                return;
            }

            var filtered = _allSchedules
                .Where(s => !string.IsNullOrEmpty(s.PatientName) && s.PatientName.ToLower().Contains(keyword))
                .ToList();

            ScheduleDataGrid.ItemsSource = filtered;
        }

        private void ScheduleDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ScheduleDataGrid.SelectedItem is not DoctorScheduleDisplayDto dto) return;

            if (dto.PatientId is null)
            {
                MessageBox.Show("Lịch này không có bệnh nhân gắn kèm.",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var record = _healthRecordService.GetAll()
                                             .FirstOrDefault(hr => hr.ScheduleId == dto.ScheduleId);

            if (record == null)
            {
                MessageBox.Show("Không tìm thấy hồ sơ sức khỏe.",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var detailWin = new HealthRecordEditWindow(record, _currentUser);
            detailWin.ShowDialog();
            LoadSchedule();
        }
    }
}
