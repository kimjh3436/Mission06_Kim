using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Kim.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public int CategoryId { get; set; }  // ✅ Foreign Key to Categories table

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }  // ✅ Navigation property

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        public string? Rating { get; set; }  // Nullable

        [Required]
        public bool Edited { get; set; }  // Boolean (0/1)

        public string? LentTo { get; set; }  // Nullable

        [Required]
        public bool CopiedToPlex { get; set; }  // Boolean (0/1)

        public string? Notes { get; set; }   // Nullable
    }
}
