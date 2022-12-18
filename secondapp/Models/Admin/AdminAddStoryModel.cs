using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Models.Admin
{
    public class AdminAddStoryModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Title { get; init; }


        [Display(Name = "Genre")]
        public int GenreId { get; init; }


        [Display(Name = "Image Url")]
        [Url]
        public string ImageUrl { get; init; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Topic { get; init; }

        [Display(Name = "Your Pseudonym/Anonymous")]
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Pseudonym { get; init; }


        [Display(Name = "Your Age")]
        [Range(16, 100)]
        public int Age { get; init; }

        [Required]
        [MinLength(2)]
        [MaxLength(3)]
        public string Public { get; init; }


        [Display(Name = "Story")]
        [MinLength(40)]
        [MaxLength(8097)]
        public string StoryText { get; init; }

        public IEnumerable<AdminStoryGenreModel> Genres { get; set; }
    }
}
