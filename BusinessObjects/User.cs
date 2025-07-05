using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Table("Users", Schema = "dbo")]
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? AccountStatus { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long? RoleId { get; set; }

        public User() { }

        public User(long id, string? fullName, string? address, string? gender, string? accountStatus,
                    string? phoneNumber, string? email, string? username, 
                    string? password, DateTime? dateOfBirth, long? roleId)
        {
            Id = id;
            FullName = fullName;
            Address = address;
            Gender = gender;
            AccountStatus = accountStatus;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = username;
            Password = password;
            DateOfBirth = dateOfBirth;
            RoleId = roleId;
        }
    }
}
