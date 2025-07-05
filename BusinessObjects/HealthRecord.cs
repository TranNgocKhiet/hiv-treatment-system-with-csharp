using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("HealthRecord", Schema = "dbo")]
    public partial class HealthRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? HivStatus { get; set; }
        public string? BloodType { get; set; }
        public string? TreatmentStatus { get; set; }
        public Double? Weight { get; set; }
        public Double? Height { get; set; }
        public long? ScheduleId { get; set; }
        public long? RegimenId { get; set; }

        public HealthRecord() { }

        public HealthRecord(long id, string? hivStatus, string? bloodType, string? treatmentStatus,
                            float? weight, float? height, long? scheduleId, long? regimenId)
        {
            Id = id;
            HivStatus = hivStatus;
            BloodType = bloodType;
            TreatmentStatus = treatmentStatus;
            Weight = weight;
            Height = height;
            ScheduleId = scheduleId;
            RegimenId = regimenId;
        }
    }
}
