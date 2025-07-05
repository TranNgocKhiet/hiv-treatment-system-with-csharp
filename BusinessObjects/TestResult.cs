using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("TestResult", Schema = "dbo")]
    public partial class TestResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Unit { get; set; }
        public string? Type { get; set; }
        public string? Result { get; set; }
        public string? Note { get; set; }
        public DateTime? ExpectedResultTime { get; set; }
        public DateTime? ActualResultTime { get; set; }
        public long? HealthRecordId { get; set; }

        public TestResult() { }

        public TestResult(long id, string? unit, string? type, string? result, string? note,
                          DateTime? expectedTimeOfResult, DateTime? actualTimeOfResult, long? healthRecordId)
        {
            Id = id;
            Unit = unit;
            Type = type;
            Result = result;
            Note = note;
            ExpectedResultTime = expectedTimeOfResult;
            ActualResultTime = actualTimeOfResult;
            HealthRecordId = healthRecordId;
        }
    }
}
