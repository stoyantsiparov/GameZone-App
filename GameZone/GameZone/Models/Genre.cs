using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Жанр")]
        public string Name { get; set; } = null!;

        public ICollection<Game>? Games { get; set; }
    }
}