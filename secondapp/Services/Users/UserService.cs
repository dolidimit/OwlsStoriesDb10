using secondapp.Data;
using System.Linq;

namespace secondapp.Services.Users
{
    public class UserService : IUserService
    {

        private readonly BookAppDbContext data;

        public UserService(BookAppDbContext data)
        {
            this.data = data;
        }

        public UsersQueryServiceModel BookStories(int currentpage, int storiesper, string userId)
        {

            var userstry = this.data.Stories.Where(x => x.UserId == userId && x.Public == "yes").AsQueryable();

            var storiesallr = userstry.Count();

            var stories = userstry
                .Skip((currentpage - 1) * storiesper)
                .Take(storiesper)
                .OrderBy(x => x.Id)
                .Where(x => x.UserId == userId && x.Public.ToLower() == "yes")
                .Select(s => new UsersDataServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    StoryText = s.StoryText
                })
                .ToList();

  
            return new UsersQueryServiceModel
            {
                TotalBookStories = storiesallr,
                CurrentPage = currentpage,
                StoriesPerBookPage = storiesper,
                BookStories = stories
            };

        }


        public UsersQueryServiceModel UsersStories(int currentpage,int storiesper, string userId)
        {
            var userstry = this.data.Stories.Where(x => x.UserId == userId).AsQueryable();

            var storiesallr = userstry.Count();

            var stories = userstry
                .Skip((currentpage - 1) * storiesper)
                .Take(storiesper)
                .OrderBy(x => x.Id)
                .Where(x => x.UserId == userId)
                .Select(s => new UsersDataServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    StoryText = s.StoryText
                })
                .ToList();


            return new UsersQueryServiceModel
            {
                TotalBookStories = storiesallr,
                CurrentPage = currentpage,
                StoriesPerUsersPage = storiesper,
                UsersStories = stories
            };
        }

      
        public UsersQueryServiceModel UsersPosts(int currentpage, int storiesper, string userId)
        {
            var userstry = this.data.Posts.Where(x => x.UserId == userId).AsQueryable();

            var storiesallr = userstry.Count();

            var stories = userstry
                .OrderBy(x => x.Id)
                .Select(s => new UsersDataServiceModel
                {
                    Id = s.Id,
                    PostTopic = s.PostTopic,
                    PostContent = s.PostContent,
                    PCurrentTime = s.PCurrentTime,
                    UserEmailC = s.UserEmailC
                })          
                .ToList();


            return new UsersQueryServiceModel
            {
                TotalUsersPosts = storiesallr,
                CurrentPage = currentpage,
                UsersPosts = stories
            };
        }

        public UsersQueryServiceModel UsersFavourites(int currentpage, int storiesper, string userId)
        {
            var userstry = this.data.FavouriteItems.Where(x => x.UserId == userId).AsQueryable();

            var storiesallr = userstry.Count();

            var stories = userstry
                .Skip((currentpage - 1) * storiesper)
                .Take(storiesper)
                .OrderBy(x => x.Id)
                .Where(x => x.UserId == userId)
                .Select(s => new UsersDataServiceModel
                {
                    Id = s.Id             
                })

                .ToList();


            return new UsersQueryServiceModel
            {
                TotalFavourites = storiesallr,
                CurrentPage = currentpage,
                AllUsersStoriesPerPage = storiesper,
                UsersFavourites = stories
            };
        }

    }
}
