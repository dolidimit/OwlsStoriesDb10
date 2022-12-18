using secondapp.Data;
using System.Linq;
using secondapp.Data.Models;
using System.Collections.Generic;


namespace secondapp.Services.Stories
{
    public class StoryService : IStoryService
    {
        private readonly BookAppDbContext data;


        public StoryService(BookAppDbContext data)
        {
            this.data = data;
        }

        public StoriesQueryServiceModel AllMine(string searchterm, int currentpage, int storiesper, string userId)
        {
            var storquery = this.data.Stories.Where(x => x.UserId == userId).AsQueryable();


            if (!string.IsNullOrWhiteSpace(searchterm))
            {
                storquery = storquery.Where(s => (s.Title + " " + s.Topic).ToLower()
                .Contains(searchterm.ToLower()) || s.StoryText.ToLower().Contains(searchterm.ToLower()));
            }

            var totstor = storquery.Count();

            var stories = storquery
                .Skip((currentpage - 1) * storiesper)
                .Take(storiesper)
                .OrderBy(x => x.Id)
                .Where(x => x.UserId == userId)
                .Select(s => new StoriesServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    StoryText = s.StoryText
                })
                .ToList();

            var genresli = this.data
                .Stories
                .Select(s => s.Genre.Name)
                .Distinct()
                .OrderBy(st => st)
                .ToList();

            return new StoriesQueryServiceModel
            {
                TotalStories = totstor,
                Genres = genresli,
                CurrentPage = currentpage,
                Stories = stories
            };
        }


        public int Create(string title, int genreId, string topic, string imageurl, string pseudonym, int age, 
            string publicm, string description, string userId)
        {

            var storyda = new Story
            {     
                Title = title,
                GenreId = genreId,
                Topic = topic,
                ImageUrl = imageurl,
                Pseudonym = pseudonym,
                Age = age,
                Public = publicm.ToLower(),
                StoryText = description,
                UserId = userId
            };

            this.data.Stories.Add(storyda);
            this.data.SaveChanges();

            return storyda.Id;
        }

        public bool Delete(int id)
        {
            var story = this.data.Stories.Find(id);

            this.data.Stories.Remove(story);
            this.data.SaveChanges();

            return true;
        }

        public StoriesServiceModel Details(int id)
            => this.data.Stories.Where(x => x.Id == id)
                .Select(x => new StoriesServiceModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Topic = x.Topic,
                    ImageUrl = x.ImageUrl,
                    Pseudonym = x.Pseudonym,
                    Age = x.Age,
                    Genre = x.Genre.Name,
                    GenreId = x.GenreId,
                    StoryText = x.StoryText,
                    Public = x.Public
                })
                .FirstOrDefault();


        public bool Edit(int id, string title, int genreId, string topic, string imageurl, string pseudonym, int age, string publicm, string description)
        {
            var storyda = this.data.Stories.Find(id);

            storyda.Title = title;
            storyda.GenreId = genreId;
            storyda.Topic = topic;
            storyda.ImageUrl = imageurl;
            storyda.Pseudonym = pseudonym;
            storyda.Age = age;
            storyda.Public = publicm;
            storyda.StoryText = description;
            storyda.Public = publicm;

            this.data.SaveChanges();

            return true;
        }

        public bool SendUsersBook(string userId)
        {
            var user = this.data.Users.Where(x => x.Id == userId).FirstOrDefault();
            var bookstories = this.data.Stories.Where(x => x.UserId == userId && x.Public.ToLower() == "yes").AsQueryable();

            if (bookstories.Count() >= 30)
            {
                foreach (var st in bookstories)
                {
                    var finshbst = new FinshedBook
                    {
                        UserId = user.Id,
                        User = user,
                        StoryId = st.Id,
                        Story = st
                    };


                    var stordata = new FinishedStory
                    {
                        StoryId = st.Id,
                        StoryTitle = st.Title,
                        StoryTopic = st.Topic,
                        StoryAuthor = st.Pseudonym,
                        StoryText = st.StoryText,
                        StoryUserId = user.Id
                    };

                    user.FinshedBooksU.Add(finshbst);

                    this.data.FinshedBooksUs.Add(finshbst);
                    this.data.FinishedStories.Add(stordata);
                }


                this.data.Stories.RemoveRange(bookstories);
                this.data.SaveChanges();

            }



            return true;

        }


    }
}
