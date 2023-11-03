namespace movies_project.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
    }
}
