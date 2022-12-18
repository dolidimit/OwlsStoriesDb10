using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Data.Models
{

    public class FinishedStory
    {
        public int Id { get; init; }
        public int StoryId { get; set; }

        [Required]
        [MaxLength(45)]
        public string StoryTitle { get; set; }

        [Required]
        [MaxLength(80)]
        public string StoryTopic { get; set; }

        [Required]
        [MaxLength(50)]
        public string StoryAuthor { get; set; }

        public string StoryUserId { get; set; }

        [Required]
        [MaxLength(8080)]
        public string StoryText { get; set; }
    }
}
