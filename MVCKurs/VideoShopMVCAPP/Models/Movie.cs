using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VideoShopMVCAPP.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bitte geben Sie ein Filmtitel ein")]
        public string Title { get; set; } = default!;

        [Required]
        [MaxLength(35)]
        public string Description { get; set; } = default!;

        [Range(0.1, 99.99)]
        public decimal? Price { get; set; }

        [Required]
        [DisplayName("Film-Genre")]
        public GenreTyp Genre { get; set; }
    }

    public enum GenreTyp { Action, Drama, Thriller, Horror, Roamnce, Comedy, Animations, Documentation, Classic }
}
