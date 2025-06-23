using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Test_Result", Schema = "dbo")]
    public partial class TestResult
    {
        [Key]
        public long Id { get; set; }
        public string Unit { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
        public string Note { get; set; }
        public DateTime ExpectedTimeOfResult { get; set; }
        public DateTime ActualTimeOfResult { get; set; }
        public long HealthRecordId { get; set; }

        public TestResult() { }

        public TestResult(long id, string unit, string type, string result, string note,
                          DateTime expectedTimeOfResult, DateTime actualTimeOfResult, long healthRecordId)
        {
            Id = id;
            Unit = unit;
            Type = type;
            Result = result;
            Note = note;
            ExpectedTimeOfResult = expectedTimeOfResult;
            ActualTimeOfResult = actualTimeOfResult;
            HealthRecordId = healthRecordId;
        }
    }
}
