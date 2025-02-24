using System.Collections.Generic;

namespace Mission06_Kim.Models
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }   // For the form
        public List<Movie> Movies { get; set; }  // For the table
    }
}
