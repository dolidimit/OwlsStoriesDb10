using secondapp.Services.Stories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Models.Stories
{
    public class AllQueryStoriesModel
    {

        public const int StoriesPerPage = 12;

        public string Topic { get; init; }

        public string Genre { get; init; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalStories { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Topics { get; set; }

        public IEnumerable<StoriesServiceModel> Stories { get; set; }

    }
}
