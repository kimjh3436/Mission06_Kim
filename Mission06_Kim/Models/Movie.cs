using System.ComponentModel.DataAnnotations;

namespace Mission06_Kim.Models
{
    public class Movie // creating a movie classing. setting the values, data types and if null or not null
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Rating { get; set; }  // Dropdown (G, PG, PG-13, R)

        public bool? Edited { get; set; }   // Yes/No (true/false)

        public string? LentTo { get; set; } // Optional

        [MaxLength(25)]
        public string? Notes { get; set; }  // Limited to 25 characters
    }
}
