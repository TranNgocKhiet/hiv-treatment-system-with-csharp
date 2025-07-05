using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Regimen", Schema = "dbo")]
    public partial class Regimen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Components { get; set; }
        public string? RegimenName { get; set; }
        public string? Description { get; set; }
        public string? Indications { get; set; }
        public string? Contraindications { get; set; }
        public long? DoctorId { get; set; }

        public Regimen() { }

        public Regimen(long id, string? components, string? regimenName, string? description,
                       string? indications, string? contraindications, long? doctorId)
        {
            Id = id;
            Components = components;
            RegimenName = regimenName;
            Description = description;
            Indications = indications;
            Contraindications = contraindications;
            DoctorId = doctorId;
        }
    }
}
