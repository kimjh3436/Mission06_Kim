using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Mission06_Kim.Models
{
    public class Category // Represents a category for movies, such as genre
    {
        [Key] // Primary key for the Category table
        [Required] // Ensures CategoryId is required
        public int CategoryId { get; set; }

        [Required] // Ensures CategoryName is required
        public string CategoryName { get; set; }

        // Navigation property: A category can be associated with multiple movies
        public ICollection<Movie> Movies { get; set; }
    }
}
