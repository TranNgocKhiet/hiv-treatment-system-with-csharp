using BusinessObjects;
using DataAccessLayer;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HivTreatmentAppWPF.Manager
{
    public partial class ManagerSchedulePage : Page
    {
        private readonly IScheduleService scheduleService;
        private readonly HivDbContext dbContext = new();

        // Lưu tất cả lịch để lọc
        private List<ScheduleDto> AllSchedules = new();

        public class ScheduleDto
        {
            public long Id { get; set; }
            public string? Type { get; set; }
            public string? RoomCode { get; set; }
            public string? ActiveStatus { get; set; }
            public string? RequestStatus { get; set; }
            public DateTime? Date { get; set; }
            public TimeSpan? Slot { get; set; }
            public string? SlotString => Slot?.ToString(@"hh\:mm");
            public string? DoctorName { get; set; }
            public long? DoctorId { get; set; }
            public long? PatientId { get; set; }
        }

        public ManagerSchedulePage()
        {
            InitializeComponent();
            var scheduleRepository = new ScheduleRepository(dbContext);
            scheduleService = new ScheduleService(scheduleRepository);
            LoadScheduleData();
        }

        private void LoadScheduleData()
        {
            var schedules = scheduleService.GetWherePatientNull();
            AllSchedules = schedules.Select(s => new ScheduleDto
            {
                Id = s.Id,
                Type = s.Type,
                RoomCode = s.RoomCode,
                ActiveStatus = s.ActiveStatus,
                RequestStatus = s.RequestStatus,
                Date = s.Date,
                Slot = s.Slot,
                DoctorId = s.DoctorId,
                PatientId = s.PatientId,
                DoctorName = dbContext.Users.FirstOrDefault(u => u.Id == s.DoctorId)?.FullName ?? "(Không có)"
            })
            .OrderBy(s => s.Date)
            .ThenBy(s => s.Slot)
            .ToList();

            ScheduleDataGrid.ItemsSource = AllSchedules;
        }

        private void ApplyFilter()
        {
            string keyword = SearchBox?.Text?.Trim().ToLower() ?? "";

            var filtered = AllSchedules.Where(s =>
                string.IsNullOrEmpty(keyword) ||
                (s.DoctorName ?? "").ToLower().Contains(keyword) ||
                (s.RoomCode ?? "").ToLower().Contains(keyword)
            ).ToList();

            ScheduleDataGrid.ItemsSource = filtered;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SlotEditDialog();
            if (dialog.ShowDialog() != true) return;

            var newSchedules = dialog.ResultSchedules;
            if (newSchedules is { Count: > 0 })
            {
                foreach (var schedule in newSchedules)
                {
                    scheduleService.Add(schedule);
                }

                MessageBox.Show($"Đã thêm {newSchedules.Count} slot mới.");
                LoadScheduleData();
            }
        }

        private void ScheduleDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ScheduleDataGrid.SelectedItem is not ScheduleDto selected) return;

            var existing = scheduleService.GetById(selected.Id);
            if (existing == null)
            {
                MessageBox.Show("Không tìm thấy lịch.");
                return;
            }

            var dialog = new SlotEditDialog(existing);
            if (dialog.ShowDialog() != true) return;

            var updated = dialog.ResultSchedules.FirstOrDefault();
            if (updated != null)
            {
                scheduleService.Update(updated);
                MessageBox.Show("Đã cập nhật lịch.");
                LoadScheduleData();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleDataGrid.SelectedItem is not ScheduleDto selected)
            {
                MessageBox.Show("Vui lòng chọn một lịch để xóa.");
                return;
            }

            var schedule = scheduleService.GetById(selected.Id);
            if (schedule == null)
            {
                MessageBox.Show("Không tìm thấy lịch.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa lịch này?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm != MessageBoxResult.Yes) return;

            if (schedule.PatientId != null)
            {
                schedule.ActiveStatus = "Đã hủy";
                scheduleService.Update(schedule);
                MessageBox.Show("Lịch đã có bệnh nhân. Đã cập nhật trạng thái thành 'Đã hủy'.");
            }
            else
            {
                scheduleService.Delete(schedule.Id);
                MessageBox.Show("Đã xóa lịch.");
            }

            LoadScheduleData();
        }
    }
}
