using BusinessObjects;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HivTreatmentAppWPF.LabTechnician.Components
{
    public partial class EditTestResultWindow : Window
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly ITestResultService _testResultService;
        private HealthRecord _healthRecord;

        public List<TestResult> TestResults { get; set; }

        public EditTestResultWindow(List<TestResult> testResults, HealthRecord healthRecord,
            IHealthRecordService healthRecordService, ITestResultService testResultService)
        {
            InitializeComponent();

            TestResults = testResults;
            _healthRecord = healthRecord;
            _healthRecordService = healthRecordService;
            _testResultService = testResultService;

            DataContext = this;

            BloodTypeTextBox.Text = _healthRecord.BloodType;

            HivStatusComboBox.SelectedItem = HivStatusComboBox.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == _healthRecord.HivStatus);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _healthRecord.BloodType = BloodTypeTextBox.Text;
                _healthRecord.HivStatus = (HivStatusComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

                _healthRecordService.Update(_healthRecord);

                foreach (var tr in TestResults)
                {
                    _testResultService.Update(tr);
                }

                MessageBox.Show("Đã lưu kết quả xét nghiệm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu kết quả: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
