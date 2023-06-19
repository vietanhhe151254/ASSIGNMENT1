using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [JsonIgnore]
        public virtual Publisher? Publisher { get; set; }

        public int PublisherId { get; set; }
        public DateTime HireDate { get; set; }
        [JsonIgnore]
        public virtual Role? Role { get; set; }
        public int RoleId { get; set; }

    }
}