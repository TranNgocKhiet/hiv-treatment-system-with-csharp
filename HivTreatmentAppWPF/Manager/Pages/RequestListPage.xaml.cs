using BusinessObjects;
using DataAccessLayer;
using HivTreatmentAppWPF.Manager.Components;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HivTreatmentAppWPF.Manager
{
    public class ScheduleDisplayDTO
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string RoomCode { get; set; }
        public string ActiveStatus { get; set; }
        public string RequestStatus { get; set; }
        public DateTime? Date { get; set; }
        public string Slot { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public long? DoctorId { get; set; }
        public long? PatientId { get; set; }
    }

    public partial class RequestListPage : Page
    {
        private readonly IScheduleService scheduleService;
        private readonly IHealthRecordService healthRecordService;
        private readonly HivDbContext hivDbContext = new HivDbContext();
        private List<ScheduleDisplayDTO> _displaySchedules;

        public RequestListPage()
        {
            InitializeComponent();

            var scheduleRepository = new ScheduleRepository(hivDbContext);
            scheduleService = new ScheduleService(scheduleRepository);

            var healthRecordRepository = new HealthRecordRepository(hivDbContext);
            healthRecordService = new HealthRecordService(healthRecordRepository);

            LoadScheduleData();
        }

        private void LoadScheduleData()
        {
            var schedules = scheduleService.GetWherePatientNotNull();

            _displaySchedules = schedules.Select(s => new ScheduleDisplayDTO
            {
                Id = s.Id,
                Type = s.Type,
                RoomCode = s.RoomCode,
                ActiveStatus = s.ActiveStatus,
                RequestStatus = s.RequestStatus,
                Date = s.Date,
                Slot = s.Slot?.ToString(@"hh\:mm"),
                DoctorName = hivDbContext.Users.FirstOrDefault(u => u.Id == s.DoctorId)?.FullName ?? "(Không có)",
                PatientName = hivDbContext.Users.FirstOrDefault(u => u.Id == s.PatientId)?.FullName ?? "(Không có)",
                DoctorId = s.DoctorId,
                PatientId = s.PatientId
            }).ToList();

            ScheduleDataGrid.ItemsSource = _displaySchedules;
        }

        private void ScheduleDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = ScheduleDataGrid.SelectedItem as ScheduleDisplayDTO;
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn lịch để xử lý.");
                return;
            }

            var schedule = scheduleService.GetById(selected.Id);
            if (schedule == null)
            {
                MessageBox.Show("Không tìm thấy lịch.");
                return;
            }

            var dialog = new RequestHandleDialog(schedule);
            if (dialog.ShowDialog() == true)
            {
                var updatedSchedule = dialog.ScheduleResult;
                scheduleService.Update(updatedSchedule);

                var updatedHealthRecord = dialog.HealthRecordResult;
                var existing = healthRecordService.GetByScheduleId(updatedSchedule.Id);
                if (existing == null)
                {
                    healthRecordService.Add(updatedHealthRecord);
                }

                MessageBox.Show("Cập nhật thành công.");
                LoadScheduleData();
            }
        }

        private void FilterPendingButton_Click(object sender, RoutedEventArgs e)
        {
            if (_displaySchedules == null) return;

            var pending = _displaySchedules
                .Where(s => s.RequestStatus != null && s.RequestStatus.Trim().ToLower() == "chờ duyệt")
                .ToList();

            ScheduleDataGrid.ItemsSource = pending;
        }

        private void ApplyFilter()
        {
            string keyword = SearchBox?.Text?.Trim().ToLower() ?? "";

            var filtered = _displaySchedules.Where(s =>
                (s.RoomCode ?? "").ToLower().Contains(keyword)
                || (s.DoctorName ?? "").ToLower().Contains(keyword)
                || (s.PatientName ?? "").ToLower().Contains(keyword)
            ).ToList();

            ScheduleDataGrid.ItemsSource = filtered;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox != null)
            {
                SearchBox.Text = "";
            }
            ScheduleDataGrid.ItemsSource = _displaySchedules;
        }
    }
}
