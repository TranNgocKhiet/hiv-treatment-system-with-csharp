using BusinessObjects;
using DataAccessLayer;
using HivTreatmentAppWPF.Doctor.Components;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HivTreatmentAppWPF.Doctor
{
    public partial class RegimenListPage : Page
    {
        private readonly IRegimenService _regimenService;
        private readonly User _currentUser;

        // Danh sách gốc để lọc
        private List<RegimenDisplay> _allRegimens;

        public RegimenListPage(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            var context = new HivDbContext();
            _regimenService = new RegimenService(new RegimenRepository(context));

            LoadRegimens();
        }

        private void LoadRegimens()
        {
            _allRegimens = _regimenService.GetByDoctorIdAndNull(_currentUser.Id)
                .Select(r => new RegimenDisplay
                {
                    Id = r.Id,
                    RegimenName = r.RegimenName,
                    Components = r.Components,
                    Indications = r.Indications,
                    Contraindications = r.Contraindications,
                    Description = r.Description,
                    DoctorId = r.DoctorId
                }).ToList();

            RegimenDataGrid.ItemsSource = _allRegimens;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchTextBox.Text?.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                RegimenDataGrid.ItemsSource = _allRegimens;
                return;
            }

            var filtered = _allRegimens.Where(r =>
                (!string.IsNullOrEmpty(r.RegimenName) && r.RegimenName.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(r.Components) && r.Components.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(r.Indications) && r.Indications.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(r.Contraindications) && r.Contraindications.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(r.Description) && r.Description.ToLower().Contains(keyword))
            ).ToList();

            RegimenDataGrid.ItemsSource = filtered;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var win = new RegimenEditWindow(_currentUser);
            if (win.ShowDialog() == true) LoadRegimens();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (RegimenDataGrid.SelectedItem is not RegimenDisplay item) return;
            if (item.DoctorId != _currentUser.Id)
            {
                MessageBox.Show("Bạn chỉ có thể xoá phác đồ của riêng bạn.",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận xoá phác đồ?", "Xác nhận",
                                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _regimenService.Delete(item.Id);
                LoadRegimens();
            }
        }

        private void RegimenDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RegimenDataGrid.SelectedItem is not RegimenDisplay item) return;

            if (item.DoctorId != _currentUser.Id)
            {
                MessageBox.Show("Bạn chỉ có thể chỉnh sửa phác đồ của riêng bạn.",
                                "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var regimen = _regimenService.GetById(item.Id);
            var win = new RegimenEditWindow(_currentUser, regimen);
            if (win.ShowDialog() == true) LoadRegimens();
        }

        private class RegimenDisplay
        {
            public long Id { get; set; }
            public string RegimenName { get; set; } = "";
            public string? Components { get; set; }
            public string? Indications { get; set; }
            public string? Contraindications { get; set; }
            public string? Description { get; set; }
            public long? DoctorId { get; set; }
        }
    }
}
