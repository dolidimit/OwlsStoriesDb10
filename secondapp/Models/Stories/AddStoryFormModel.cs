using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Models.Stories
{
    public class AddStoryFormModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(45)]
        public string Title { get; init; }


        [Display(Name = "Genre")]
        public int GenreId { get; init; }


        [Display(Name = "Image Url")]
        [Url]
        public string ImageUrl { get; init; }

        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        public string Topic { get; init; }

        [Display(Name = "Your Pseudonym/Anonymous")]
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Pseudonym { get; init; }


        [Display(Name = "Your Age")]
        [Range(16, 100)]
        public int Age { get; init; }

        [Required]
        [MinLength(2)]
        [MaxLength(3)]
        public string Public { get; init; }

        public int Likes { get; init; }


        public string UserId { get; init; }


        public string UserEmailC { get; init; }


        public string UserFullNameC { get; init; }


        [Display(Name = "Story")]
        [MinLength(40)]
        [MaxLength(8080)]
        public string StoryText { get; init; }

        public IEnumerable<StoryGenreModel> Genres { get; set; }

    }
}
