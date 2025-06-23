using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    [Table("Roles", Schema = "dbo")]
    public partial class Role
    {
        [Key]
        public long Id { get; set; }
        public string RoleName { get; set; }

        public Role() { }

        public Role(long id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }
    }
}
