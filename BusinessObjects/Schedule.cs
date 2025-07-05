using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Schedule", Schema = "dbo")]
    public partial class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Type { get; set; }
        public string? RoomCode { get; set; }
        public string? ActiveStatus { get; set; }
        public string? RequestStatus { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Slot { get; set; }
        public long? DoctorId { get; set; }
        public long? PatientId { get; set; }

        public Schedule() { }

        public Schedule(long id, string? type, string? roomCode, string? activeStatus, string? requestStatus, DateTime? date,
                        TimeSpan? slot, long? doctorId, long? patientId)
        {
            Id = id;
            Type = type;
            RoomCode = roomCode;
            ActiveStatus = activeStatus;
            RequestStatus = requestStatus;
            Date = date;
            Slot = slot;
            DoctorId = doctorId;
            PatientId = patientId;
        }
    }
}
