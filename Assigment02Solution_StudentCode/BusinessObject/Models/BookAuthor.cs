using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BusinessObject.Models
{
    public class BookAuthor
    {
        [Key]
        public int AuthorId { get; set; }
        public virtual Book Book { get; set; }
        [Key]
        public int BookId { get; set; }

        public virtual Author Author { get; set; }

        [Required]
        public string AuthorOder { get; set; }

        [Required]
        public int RoyaltyPerventage  { get; set; }

    }
}