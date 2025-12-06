using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Име на студио")]
        public string Name { get; set; } = null!;

        [Display(Name = "Уебсайт")]
        public string? Website { get; set; }

        public ICollection<Game>? Games { get; set; }
    }
}