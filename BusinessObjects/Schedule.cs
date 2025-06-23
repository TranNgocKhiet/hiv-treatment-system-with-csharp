using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Schedule", Schema = "dbo")]
    public partial class Schedule
    {
        [Key]
        public long Id { get; set; }
        public string Type { get; set; }
        public string RoomCode { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Slot { get; set; }
        public long DoctorId { get; set; }
        public long PatientId { get; set; }

        public Schedule() { }

        public Schedule(long id, string type, string roomCode, string status, DateTime date,
                        TimeSpan slot, long doctorId, long patientId)
        {
            Id = id;
            Type = type;
            RoomCode = roomCode;
            Status = status;
            Date = date;
            Slot = slot;
            DoctorId = doctorId;
            PatientId = patientId;
        }
    }
}
