using secondapp.Data;
using System.Linq;

namespace secondapp.Services.Admin
{
    public class AdminService : IAdminService
    {

        private readonly BookAppDbContext data;

        public AdminService(BookAppDbContext data)
        {
            this.data = data;
        }

        public AdminQueryServiceModel AllStories(
           int currentpage,
           int itemssperpage)
        {
            var storquery = this.data.Stories.AsQueryable();

            var totalstor = storquery.Count();

            var stories = storquery
                .Skip((currentpage - 1) * itemssperpage)
                .Take(itemssperpage)
                .OrderBy(x => x.Id)
                .Where(x => x.Public.ToLower() == "yes")
                .Select(s => new AdminServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    StoryText = s.StoryText
                })
                .ToList();

           

            return new AdminQueryServiceModel
            {
                TotalStories = totalstor,
                CurrentPage = currentpage,
                Stories = stories
            };

        }


        public AdminQueryServiceModel AllPosts(
           int currentpage,
           int itemssperpage)
        {
            var postquery = this.data.Posts.AsQueryable();

            var totalstor = postquery.Count();

            var posts = postquery
                .Skip((currentpage - 1) * itemssperpage)
                .Take(itemssperpage)
                .OrderBy(x => x.Id)
                .Select(s => new AdminPostServiceModel
                {
                    Id = s.Id,
                    PostTopic = s.PostTopic,
                    PostContent = s.PostContent
                })
                .ToList();

            
            return new AdminQueryServiceModel
            {
                TotalPosts = totalstor,
                CurrentPage = currentpage,
                Posts = posts
            };

        }

        public AdminQueryServiceModel PublicBooks(
           int currentpage,
           int itemssperpage)
        {
            var postquery = this.data.Books.AsQueryable();

            var bookstor = postquery.Count();

            var books = postquery
                .Skip((currentpage - 1) * itemssperpage)
                .Take(itemssperpage)
                .OrderBy(x => x.Id)
                .Select(s => new AdminBookServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageUrl = s.ImageUrl
                })
                .ToList();


            return new AdminQueryServiceModel
            {
                TotalBooks = bookstor,
                CurrentPage = currentpage,
                Books = books
            };

        }


        public AdminQueryServiceModel PublicStories(
             string searchterm,
           int currentpage,
           int itemssperpage)
        {
            var storquery = this.data.Stories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchterm))
            {
                storquery = storquery.Where(s => (s.Title + " ").ToLower()
                .Contains(searchterm.ToLower()) || s.StoryText.ToLower().Contains(searchterm.ToLower()));
            }


            var stories = storquery
                .Skip((currentpage - 1) * itemssperpage)
                .Take(itemssperpage)
                .OrderBy(x => x.Id)
                .Where(x => x.Public.ToLower() == "yes")
                .Select(s => new AdminServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    StoryText = s.StoryText
                })
                .ToList();

            var totalstor = storquery.Count();



            return new AdminQueryServiceModel
            {
                TotalStories = totalstor,
                CurrentPage = currentpage,
                ItemsPerPage = itemssperpage,
                SearchTerm = searchterm,
                Stories = stories
            };

        }

        public AdminQueryServiceModel PublicStoriesUser(
            string searchterm,
          int currentpage,
          int itemssperpage,string userid)
        {
            var storquery = this.data.Stories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchterm))
            {
                storquery = storquery.Where(s => (s.Title + " ").ToLower()
                .Contains(searchterm.ToLower()) || s.StoryText.ToLower().Contains(searchterm.ToLower()));
            }


            var stories = storquery
                .Skip((currentpage - 1) * itemssperpage)
                .Take(itemssperpage)
                .OrderBy(x => x.Id)
                .Where(x => x.Public.ToLower() == "yes" && x.UserId != userid)
                .Select(s => new AdminServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    StoryText = s.StoryText
                })
                .ToList();

            var totalstor = storquery.Count();



            return new AdminQueryServiceModel
            {
                TotalStories = totalstor,
                CurrentPage = currentpage,
                ItemsPerPage = itemssperpage,
                SearchTerm = searchterm,
                Stories = stories
            };

        }

        public AdminStoryServiceModel DetailsStory(int id)
               => this.data.Stories.Where(x => x.Id == id)
         .Select(x => new AdminStoryServiceModel
         {
             Title = x.Title,
             Topic = x.Topic,
             ImageUrl = x.ImageUrl,
             Genre = x.Genre.Name,
             Pseudonym = x.Pseudonym,
             StoryText = x.StoryText
         })
         .FirstOrDefault();

        public AdminStoryServiceModel DetailsStoryUser(int id)
               => this.data.Stories.Where(x => x.Id == id)
         .Select(x => new AdminStoryServiceModel
         {
             Title = x.Title,
             Topic = x.Topic,
             ImageUrl = x.ImageUrl,
             Genre = x.Genre.Name,
             Pseudonym = x.Pseudonym,
             StoryText = x.StoryText
         })
         .FirstOrDefault();

      

        public bool EditStory(int id, string title, int genreId, string topic, string imageurl, string pseudonym, string description)
        {
            var storyda = this.data.Stories.Find(id);

            storyda.Title = title;
            storyda.GenreId = genreId;
            storyda.ImageUrl = imageurl;
            storyda.Topic = topic;
            storyda.StoryText = description;

            this.data.SaveChanges();

            return true;
        }

        public bool DeleteStory(int id)
        {
            var book = this.data.Stories.Find(id);

            this.data.Stories.Remove(book);
            this.data.SaveChanges();

            return true;
        }

    }
}
