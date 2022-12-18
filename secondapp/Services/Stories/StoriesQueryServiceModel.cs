using System.Collections.Generic;

namespace secondapp.Services.Stories
{
    public class StoriesQueryServiceModel
    {
        public int StoriesPerPage { get; init; }

        public int CurrentPage { get; init; } 

        public int TotalStories { get; init; }

        public string Genre { get; init; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<StoriesServiceModel> Stories { get; init; }
    }
}
