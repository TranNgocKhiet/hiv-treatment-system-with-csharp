using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Doctor_Profile", Schema = "dbo")]
    public partial class DoctorProfile
    {
        [Key]
        public long Id { get; set; }
        public string Qualifications { get; set; }
        public string Background { get; set; }
        public string Biography { get; set; }
        public string LicenseNumber { get; set; }
        public string StartYear { get; set; }
        public long UserId { get; set; }

        public DoctorProfile() { }

        public DoctorProfile(long id, string qualifications, string background, string biography,
                             string licenseNumber, string startYear, long userId)
        {
            Id = id;
            Qualifications = qualifications;
            Background = background;
            Biography = biography;
            LicenseNumber = licenseNumber;
            StartYear = startYear;
            UserId = userId;
        }
    }
}
