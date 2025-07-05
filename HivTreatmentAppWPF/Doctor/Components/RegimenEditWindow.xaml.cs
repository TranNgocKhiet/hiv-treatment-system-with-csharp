using System.Windows;
using BusinessObjects;
using DataAccessLayer;
using DataAccessObjects;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;

namespace HivTreatmentAppWPF.Doctor.Components
{
    public partial class RegimenEditWindow : Window
    {
        private readonly User _currentUser;
        private readonly Regimen _currentRegimen;
        private readonly IRegimenService _regimenService;
        private readonly bool _isEditMode;

        public RegimenEditWindow(User user)
        {
            InitializeComponent();

            _currentUser = user;
            _currentRegimen = new Regimen { DoctorId = user.Id };
            _isEditMode = false;

            _regimenService = new RegimenService(new RegimenRepository(new HivDbContext()));
        }

        public RegimenEditWindow(User user, Regimen regimen)
        {
            InitializeComponent();

            _currentUser = user;
            _currentRegimen = regimen;
            _isEditMode = true;

            _regimenService = new RegimenService(new RegimenRepository(new HivDbContext()));

            LoadRegimenData();
        }

        private void LoadRegimenData()
        {
            RegimenNameTextBox.Text = _currentRegimen.RegimenName;
            ComponentsTextBox.Text = _currentRegimen.Components;
            IndicationsTextBox.Text = _currentRegimen.Indications;
            ContraindicationsTextBox.Text = _currentRegimen.Contraindications;
            DescriptionTextBox.Text = _currentRegimen.Description;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu từ form
            _currentRegimen.RegimenName = RegimenNameTextBox.Text.Trim();
            _currentRegimen.Components = ComponentsTextBox.Text.Trim();
            _currentRegimen.Indications = IndicationsTextBox.Text.Trim();
            _currentRegimen.Contraindications = ContraindicationsTextBox.Text.Trim();
            _currentRegimen.Description = DescriptionTextBox.Text.Trim();

            try
            {
                if (_isEditMode)
                {
                    _regimenService.Update(_currentRegimen);
                }
                else
                {
                    _regimenService.Add(_currentRegimen);
                }

                DialogResult = true;
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phác đồ: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
