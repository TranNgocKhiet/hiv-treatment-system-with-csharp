using BusinessObjects;
using DataAccessLayer;
using RepositoryLayer;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HivTreatmentAppWPF.Manager
{
    public partial class SlotEditDialog : Window
    {
        private readonly UserService _userService;
        private readonly List<User> _allDoctors;
        private readonly ObservableCollection<User> _filteredDoctors;

        public List<Schedule> ResultSchedules { get; private set; } = new();
        public bool IsEdit { get; }

        private readonly Schedule _editingSchedule;

        public SlotEditDialog(Schedule? schedule = null)
        {
            InitializeComponent();

            var ctx = new HivDbContext();
            _userService = new UserService(new UserRepository(ctx), new RoleRepository(ctx));

            _allDoctors = _userService.GetAllDoctors();
            _filteredDoctors = new ObservableCollection<User>(_allDoctors);

            DoctorComboBox.ItemsSource = _filteredDoctors;
            DoctorComboBox.DisplayMemberPath = nameof(User.FullName);
            DoctorComboBox.SelectedValuePath = nameof(User.Id);

            for (int h = 7; h <= 17; h++) SlotComboBox.Items.Add($"{h:D2}:00");

            IsEdit = schedule != null;
            _editingSchedule = schedule ?? new Schedule { ActiveStatus = "Đang hoạt động" };

            BindScheduleToUI(_editingSchedule);
        }

        private void SearchDoctorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string kw = SearchDoctorTextBox.Text.Trim();
            _filteredDoctors.Clear();

            var list = string.IsNullOrWhiteSpace(kw)
                     ? _allDoctors
                     : _userService.GetDoctorsByName(kw);

            foreach (var d in list) _filteredDoctors.Add(d);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput()) return;

            int count = 1;
            if (!IsEdit)
            {
                if (!int.TryParse(SlotCountTextBox.Text, out count) || count <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng slot hợp lệ (>0).");
                    return;
                }
            }

            string room = RoomCodeTextBox.Text.Trim();
            DateTime date = DatePicker.SelectedDate!.Value;
            TimeSpan slot = TimeSpan.Parse(SlotComboBox.SelectedItem!.ToString()!);
            long docId = (long)DoctorComboBox.SelectedValue!;

            if (IsEdit)
            {
                UpdateSchedule(_editingSchedule, room, date, slot, docId);
                ResultSchedules = new List<Schedule> { _editingSchedule };
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    var s = new Schedule { ActiveStatus = "Đang hoạt động" };
                    UpdateSchedule(s, room, date, slot, docId);
                    ResultSchedules.Add(s);
                }
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => Close();

        private void BindScheduleToUI(Schedule s)
        {
            RoomCodeTextBox.Text = s.RoomCode;
            DatePicker.SelectedDate = s.Date ?? DateTime.Today;
            SlotComboBox.SelectedItem = s.Slot?.ToString(@"hh\:mm") ?? SlotComboBox.Items[0];
            DoctorComboBox.SelectedValue = s.DoctorId ?? _allDoctors.FirstOrDefault()?.Id;
        }

        private static void UpdateSchedule(Schedule target, string room, DateTime date, TimeSpan slot, long docId)
        {
            target.RoomCode = room;
            target.Date = date;
            target.Slot = slot;
            target.DoctorId = docId;
        }

        private bool ValidateInput() =>
            !string.IsNullOrWhiteSpace(RoomCodeTextBox.Text)
            && DatePicker.SelectedDate != null
            && SlotComboBox.SelectedItem != null
            && DoctorComboBox.SelectedItem != null;
    }
}
