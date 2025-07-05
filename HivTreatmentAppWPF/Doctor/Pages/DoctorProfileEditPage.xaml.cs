using BusinessObjects;
using DataAccessLayer;
using DataAccessObjects;
using RepositoryLayer;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HivTreatmentAppWPF.Doctor
{
    public partial class DoctorProfileEditPage : Page
    {
        private readonly IUserService _userService;
        private readonly IDoctorProfileService _doctorProfileService;
        private readonly HivDbContext _context = new HivDbContext();
        private readonly DoctorProfileDto _dto;
        private readonly User _user;

        public class DoctorProfileDto
        {
            public long UserId { get; set; }
            public string? FullName { get; set; }
            public string? Address { get; set; }
            public string? Gender { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Email { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
            public DateTime? DateOfBirth { get; set; }

            public string? Qualifications { get; set; }
            public string? Background { get; set; }
            public string? Biography { get; set; }
            public string? LicenseNumber { get; set; }
            public string? StartYear { get; set; }
        }

        public DoctorProfileEditPage(User user)
        {
            InitializeComponent();

            _user = user;

            var userRepository = new UserRepository(_context);
            var roleRepository = new RoleRepository(_context);
            _userService = new UserService(userRepository, roleRepository);

            var doctorReposiotry = new DoctorProfileRepository(_context);   
            _doctorProfileService = new DoctorProfileService(doctorReposiotry);

            _dto = new DoctorProfileDto
            {
                UserId = _user.Id,
                FullName = _user.FullName,
                Address = _user.Address,
                Gender = _user.Gender,
                PhoneNumber = _user.PhoneNumber,
                Email = _user.Email,
                Username = _user.Username,
                Password = _user.Password,
                DateOfBirth = _user.DateOfBirth
            };

            var doctor = _doctorProfileService.GetAll().FirstOrDefault(d => d.DoctorId == _user.Id);
            if (doctor != null)
            {
                _dto.Qualifications = doctor.Qualifications;
                _dto.Background = doctor.Background;
                _dto.Biography = doctor.Biography;
                _dto.LicenseNumber = doctor.LicenseNumber;
                _dto.StartYear = doctor.StartYear;
            }

            LoadProfile();
        }

        private void LoadProfile()
        {
            var freshUser = _userService.GetById(_user.Id);
            var doctor = _doctorProfileService.GetAll().FirstOrDefault(d => d.DoctorId == _user.Id);

            _dto.FullName = freshUser.FullName;
            _dto.Address = freshUser.Address;
            _dto.Gender = freshUser.Gender;
            _dto.PhoneNumber = freshUser.PhoneNumber;
            _dto.Email = freshUser.Email;
            _dto.Username = freshUser.Username;
            _dto.Password = freshUser.Password;
            _dto.DateOfBirth = freshUser.DateOfBirth;

            if (doctor != null)
            {
                _dto.Qualifications = doctor.Qualifications;
                _dto.Background = doctor.Background;
                _dto.Biography = doctor.Biography;
                _dto.LicenseNumber = doctor.LicenseNumber;
                _dto.StartYear = doctor.StartYear;
            }

            FullNameTextBox.Text = _dto.FullName ?? string.Empty;
            AddressTextBox.Text = _dto.Address ?? string.Empty;
            PhoneNumberTextBox.Text = _dto.PhoneNumber ?? string.Empty;
            EmailTextBox.Text = _dto.Email ?? string.Empty;
            UsernameTextBox.Text = _dto.Username ?? string.Empty;
            PasswordBox.Password = _dto.Password ?? string.Empty;
            DateOfBirthPicker.SelectedDate = _dto.DateOfBirth;

            GenderComboBox.SelectedIndex = _dto.Gender switch
            {
                "Nam" => 0,
                "Nữ" => 1,
                "Khác" => 2,
                _ => -1
            };

            QualificationsTextBox.Text = _dto.Qualifications ?? string.Empty;
            BackgroundTextBox.Text = _dto.Background ?? string.Empty;
            BiographyTextBox.Text = _dto.Biography ?? string.Empty;
            LicenseNumberTextBox.Text = _dto.LicenseNumber ?? string.Empty;
            StartYearTextBox.Text = _dto.StartYear ?? string.Empty;
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _dto.FullName = FullNameTextBox.Text;
            _dto.Address = AddressTextBox.Text;
            _dto.Gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            _dto.PhoneNumber = PhoneNumberTextBox.Text;
            _dto.Email = EmailTextBox.Text;
            _dto.Password = PasswordBox.Password;
            _dto.DateOfBirth = DateOfBirthPicker.SelectedDate;
            _dto.Qualifications = QualificationsTextBox.Text;
            _dto.Background = BackgroundTextBox.Text;
            _dto.Biography = BiographyTextBox.Text;
            _dto.LicenseNumber = LicenseNumberTextBox.Text;
            _dto.StartYear = StartYearTextBox.Text;

            try
            {
                var user = _userService.GetById(_dto.UserId);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                user.FullName = _dto.FullName;
                user.Address = _dto.Address;
                user.Gender = _dto.Gender;
                user.PhoneNumber = _dto.PhoneNumber;
                user.Email = _dto.Email;
                user.Password = _dto.Password;
                user.DateOfBirth = _dto.DateOfBirth;

                _userService.Update(user);

                var doctor = _doctorProfileService.GetAll().FirstOrDefault(d => d.DoctorId == _dto.UserId);

                if (doctor == null)
                {
                    doctor = new DoctorProfile
                    {
                        DoctorId = _dto.UserId,
                        Qualifications = _dto.Qualifications,
                        Background = _dto.Background,
                        Biography = _dto.Biography,
                        LicenseNumber = _dto.LicenseNumber,
                        StartYear = _dto.StartYear
                    };
                    _doctorProfileService.Add(doctor);
                }
                else
                {
                    doctor.Qualifications = _dto.Qualifications;
                    doctor.Background = _dto.Background;
                    doctor.Biography = _dto.Biography;
                    doctor.LicenseNumber = _dto.LicenseNumber;
                    doctor.StartYear = _dto.StartYear;

                    _doctorProfileService.Update(doctor);
                }

                LoadProfile(); 

                MessageBox.Show("Cập nhật hồ sơ thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
