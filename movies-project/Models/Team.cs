using System;
using System.Collections.Generic;

namespace movies_project.Models
{
    public partial class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedin { get; set; }
    }
}
