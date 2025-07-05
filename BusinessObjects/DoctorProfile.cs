using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("DoctorProfile", Schema = "dbo")]
    public partial class DoctorProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Qualifications { get; set; }
        public string? Background { get; set; }
        public string? Biography { get; set; }
        public string? LicenseNumber { get; set; }
        public string? StartYear { get; set; }
        public long? DoctorId { get; set; }

        public DoctorProfile() { }

        public DoctorProfile(long id, string? qualifications, string? background, string? biography,
                             string? licenseNumber, string? startYear, long? doctorId)
        {
            Id = id;
            Qualifications = qualifications;
            Background = background;
            Biography = biography;
            LicenseNumber = licenseNumber;
            StartYear = startYear;
            DoctorId = doctorId;
        }
    }
}
