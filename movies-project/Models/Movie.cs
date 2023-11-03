using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace movies_project.Models
{
    public class Movie
    { 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Story { get; set; }
        public string? Director { get; set; }
        public string? DateShow { get; set; }
        public double? Rate { get; set; }
        public string? Poster { get; set; }
        public string? Runtime { get; set; }
        public string? Actor1 { get; set; }
        public string? Actor2 { get; set; }
        public string? Actor3 { get; set; }
        public string? Actor4 { get; set; }
        public string? Trailer { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<MovieImage> MovieImages { get; set; } = new HashSet<MovieImage>();
    }
}
