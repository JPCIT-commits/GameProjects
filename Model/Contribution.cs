using System.ComponentModel.DataAnnotations;
namespace GameProjects.Model
{
    public class Contribution
    {
        //Primary key
        public int Id { get; set; }

        //Foreign key for Game
        public int GameId { get; set; }
        public Game? Game { get; set; } = null!;

        //Foreign key for Developer
        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Role { get; set; } = string.Empty;

        [StringLength(100)]
        public string? ContributionType { get; set; } = string.Empty;

        [StringLength(100)]
        public string? ContributionDescription { get; set; } = string.Empty;

        //Date of contribution
        [StringLength(100)]
        public string? ContributionDate { get; set; } = string.Empty;

    }
}
