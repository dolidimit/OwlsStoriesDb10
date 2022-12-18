using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Data.Models
{
    public class Story
    {
       
        public int Id { get; init; }

        [Required]
        [MaxLength(45)]
        public string Title { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(80)]
        public string Topic { get; set; }

        [Required]
        [MaxLength(50)]
        public string Pseudonym { get; set; }

        [Range(16, 100)]
        public int Age { get; set; }

        [Required]
        [MaxLength(3)]
        public string Public { get; set; }

        public string UserId { get; set; }

        public int Likes { get; set; } 

        [Required]
        [MaxLength(8080)]
        public string StoryText { get; set; }

        

    }
}
