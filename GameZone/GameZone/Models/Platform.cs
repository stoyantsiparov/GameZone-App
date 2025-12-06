using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Платформа")]
        public string Name { get; set; } = null!;

        public ICollection<Game>? Games { get; set; }
    }
}