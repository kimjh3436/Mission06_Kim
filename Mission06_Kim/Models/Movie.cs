using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Mission06_Kim.Models
{
    public class Movie // Represents a movie entity with necessary attributes
    {
        [Key] // Primary key for the Movie table
        [Required] // Ensures MovieId is required
        public int MovieId { get; set; }

        [Required] // Foreign key reference to Category table
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")] // Establishes relationship with Category
        [ValidateNever] // Prevents model validation on Category navigation property
        public Category Category { get; set; }

        [Required(ErrorMessage = "Title is required.")] // Title is a mandatory field
        public string Title { get; set; }

        [Required]
        [Range(1888, 2025, ErrorMessage = "You must enter a valid year")] // Restricts valid movie release years
        public int Year { get; set; }

        // Optional fields (nullable properties indicated by '?')
        public string? Director { get; set; } // director 
        public string? Rating { get; set; } // Movie rating 

        [Required(ErrorMessage = "Edited field is required.")] // Ensures Edited status is provided
        public int Edited { get; set; }

        public string? LentTo { get; set; } // Person the movie is lent to 
        public string? Notes { get; set; } // Additional notes limited to 25 characters in the UI)

        [Required(ErrorMessage = "CopiedToPlex field is required.")] // Requires status on Plex copying
        public int CopiedToPlex { get; set; }
    }
}
