using System.ComponentModel.DataAnnotations;
namespace GameProjects.Model
{
    public enum Progress { Planning, PreProduction, Production, PreLaunch, Launched, PostLaunch }
    public class Game
    {
        //Primary key
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        //Stores enum values in the database as strings
        [EnumDataType(typeof(Progress))]
        public Progress? Progress { get; set; }

        [StringLength(100)]
        public string? Genre { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Platform { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Engine { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Version { get; set; } = string.Empty;

        //Navigation property
        public ICollection<Developer> Developers { get; set; } = new List<Developer>();
    }
}
