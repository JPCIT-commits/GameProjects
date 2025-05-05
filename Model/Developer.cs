using System.ComponentModel.DataAnnotations;

namespace GameProjects.Model
{
    public class Developer
    {
        //Primary key
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public ICollection<Game> Projects { get; set; } = new List<Game>();
    }
}
