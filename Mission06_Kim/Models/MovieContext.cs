﻿using Microsoft.EntityFrameworkCore;
using Mission06_Kim.Models;

namespace Mission06_Kim.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}



