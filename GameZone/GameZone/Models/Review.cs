using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Потребител")]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(500, ErrorMessage = "Ревюто не може да е по-дълго от 500 символа.")]
        [Display(Name = "Коментар")]
        public string Content { get; set; } = null!;

        [Required]
        [Range(1, 10, ErrorMessage = "Оценката трябва да е между 1 и 10.")]
        [Display(Name = "Оценка")]
        public int Rating { get; set; }

        [Display(Name = "Дата")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public Game? Game { get; set; }
    }
}