namespace secondapp.Services.Stories
{
    public class StoriesServiceModel
    {
        public int Id { get; init; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int GenreId { get; set; }

        public string ImageUrl { get; set; }

        public string Topic { get; set; }

        public string Pseudonym { get; set; }

        public int Age { get; set; }

        public string Public { get; set; }

        public int Likes { get; set; } 

        public string StoryText { get; set; }
    }
}
