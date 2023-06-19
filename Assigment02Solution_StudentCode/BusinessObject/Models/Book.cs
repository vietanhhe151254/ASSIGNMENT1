using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Advance { get; set; }
        [Required]
        public int Royalty { get; set; }
        [Required]
        public int YtdSales { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [JsonIgnore]
        public virtual Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

        [JsonIgnore]
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}