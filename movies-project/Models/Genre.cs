using System;
using System.Collections.Generic;

namespace movies_project.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public string? Description { get; set; }

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
