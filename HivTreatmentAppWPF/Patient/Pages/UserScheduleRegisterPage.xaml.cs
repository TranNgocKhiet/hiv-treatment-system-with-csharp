using DataAccessLayer;
using RepositoryLayer;
using BusinessObjects;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HivTreatmentAppWPF.Patient
{
    public partial class UserScheduleRegisterPage : Page
    {
        private readonly IScheduleService scheduleService;
        private readonly HivDbContext _context = new HivDbContext();
        private readonly User _user;

        public UserScheduleRegisterPage(User user)
        {
            InitializeComponent();

            _user = user;

            var scheduleRepository = new ScheduleRepository(_context);
            scheduleService = new ScheduleService(scheduleRepository);

            DatePicker.SelectedDateChanged += DatePicker_SelectedDateChanged;

            DatePicker.SelectedDate = DateTime.Today;
            TypeComboBox.SelectedIndex = 0;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDate = DatePicker.SelectedDate;

            if (selectedDate == null)
            {
                SlotComboBox.Items.Clear();
                return;
            }

            var availableSchedules = scheduleService.GetAvailableSchedulesByDate(selectedDate.Value);

            if (availableSchedules == null || availableSchedules.Count == 0)
            {
                SlotComboBox.Items.Clear();
                MessageBox.Show("Ngày này hiện tại chưa có ca khám, vui lòng quay lại sau.");
                return;
            }

            SlotComboBox.Items.Clear();
            foreach (var schedule in availableSchedules.OrderBy(s => s.Slot))
            {
                if (schedule.Slot.HasValue)
                {
                    SlotComboBox.Items.Add(schedule.Slot.Value.ToString(@"hh\:mm"));
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedDate = DatePicker.SelectedDate;
            var selectedSlotStr = SlotComboBox.SelectedItem as string;
            var selectedType = (TypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedDate == null || string.IsNullOrWhiteSpace(selectedSlotStr) || string.IsNullOrWhiteSpace(selectedType))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            var parsedSlot = TimeSpan.Parse(selectedSlotStr);
            var schedule = scheduleService.GetByDateAndSlot(selectedDate.Value, parsedSlot);
            if (schedule == null)
            {
                MessageBox.Show("Hiện tại không có ca khám vào giờ này. Vui lòng quay lại sau.");
                return;
            }

            if (schedule.PatientId != null)
            {
                MessageBox.Show("Ca khám này đã có người đăng ký. Vui lòng chọn ca khác.");
                return;
            }

            schedule.Type = selectedType;
            schedule.RequestStatus = "Chờ duyệt";
            schedule.PatientId = _user.Id;

            scheduleService.Update(schedule);

            MessageBox.Show($"Đăng ký thành công!\nNgày: {selectedDate:dd/MM/yyyy}\nCa: {selectedSlotStr}\nLoại khám: {selectedType}");
        }
    }
}
