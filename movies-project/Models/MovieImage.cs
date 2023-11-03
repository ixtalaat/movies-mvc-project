using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace movies_project.Models
{
    public partial class MovieImage
    {
        public int Id { get; set; }
        public string? Photo { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
