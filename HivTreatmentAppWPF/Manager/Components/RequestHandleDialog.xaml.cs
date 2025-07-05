using BusinessObjects;
using DataAccessLayer;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HivTreatmentAppWPF.Manager.Components
{
    public partial class RequestHandleDialog : Window
    {
        public Schedule ScheduleResult { get; private set; }
        public HealthRecord HealthRecordResult { get; private set; }

        private Schedule CurrentSchedule;
        private readonly HivDbContext _dbContext = new HivDbContext();

        public class ScheduleDisplayDto
        {
            public string DoctorFullName { get; set; }
            public string PatientFullName { get; set; }
        }

        public RequestHandleDialog(Schedule schedule)
        {
            InitializeComponent();
            CurrentSchedule = schedule;
            PopulateFields();
        }

        private void PopulateFields()
        {
            var doctorName = _dbContext.Users.FirstOrDefault(u => u.Id == CurrentSchedule.DoctorId)?.FullName ?? "(Không rõ)";
            var patientName = _dbContext.Users.FirstOrDefault(u => u.Id == CurrentSchedule.PatientId)?.FullName ?? "(Không rõ)";

            RoomCodeTextBox.Text = CurrentSchedule.RoomCode;
            DateTextBox.Text = CurrentSchedule.Date?.ToString("dd/MM/yyyy");
            SlotTextBox.Text = CurrentSchedule.Slot?.ToString(@"hh\:mm");
            DoctorTextBox.Text = doctorName;
            TypeTextBox.Text = CurrentSchedule.Type;
            PatientTextBox.Text = patientName;

            foreach (ComboBoxItem item in RequestStatusComboBox.Items)
                if (item.Content?.ToString() == CurrentSchedule.RequestStatus)
                    RequestStatusComboBox.SelectedItem = item;

            foreach (ComboBoxItem item in ActiveStatusComboBox.Items)
                if (item.Content?.ToString() == CurrentSchedule.ActiveStatus)
                    ActiveStatusComboBox.SelectedItem = item;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (RequestStatusComboBox.SelectedItem is not ComboBoxItem reqItem ||
                ActiveStatusComboBox.SelectedItem is not ComboBoxItem actItem)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ trạng thái.", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ScheduleResult = new Schedule
            {
                Id = CurrentSchedule.Id,
                Type = CurrentSchedule.Type,
                RoomCode = CurrentSchedule.RoomCode,
                ActiveStatus = actItem.Content.ToString(),     
                RequestStatus = reqItem.Content.ToString(),     
                Date = CurrentSchedule.Date,
                Slot = CurrentSchedule.Slot,
                DoctorId = CurrentSchedule.DoctorId,
                PatientId = CurrentSchedule.PatientId
            };

            HealthRecordResult = new HealthRecord
            {
                ScheduleId = CurrentSchedule.Id,
                TreatmentStatus = "Chờ khám"
            };

            DialogResult = true;
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
