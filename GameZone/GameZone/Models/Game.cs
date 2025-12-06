using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Заглавие")]
        public string Title { get; set; } = null!;

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Дата на излизане")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Цена")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Картинка (URL)")]
        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(Genre))]
        [Display(Name = "Жанр")]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        [ForeignKey(nameof(Developer))]
        [Display(Name = "Разработчик")]
        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }

        [ForeignKey(nameof(Platform))]
        [Display(Name = "Платформа")]
        public int PlatformId { get; set; }
        public Platform? Platform { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}