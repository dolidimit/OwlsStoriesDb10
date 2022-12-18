using secondapp.Data;
using secondapp.Data.Models;
using System;
using System.Linq;

namespace secondapp.Services.Posts
{
    public class PostsService : IPostsService
    {

        private readonly BookAppDbContext data;

        public PostsService(BookAppDbContext data)
        {
            this.data = data;
        }

        public PostQueryServiceModel AllPosts(int currentpage, int storiesper)
        {
            var postquery = this.data.Posts.AsQueryable();

            var totstor = postquery.Count();


            var data = postquery
                .Skip((currentpage - 1) * storiesper)
                .Take(storiesper)
                .OrderBy(x => x.Id)
                .Select(s => new PostServiceModel
                {
                    Id = s.Id,
                    PostTopic = s.PostTopic,
                    PostContent = s.PostContent,
                    PCurrentTime = s.PCurrentTime,             
                    UserEmailC = s.UserEmailC

                })
                .ToList();



            return new PostQueryServiceModel
            {
                TotalPosts = totstor,              
                CurrentPage = currentpage,
                Posts = data,
            };
        }

        public int Create(string ptopic,string datacurrent, string description, string userId,string userem)
        {

            var currenttime = DateTime.Now.ToString("dd-MM-yyyy h:mm:ss tt");

            var postdt = new Post
            {
                PostTopic = ptopic,
                PostContent = description,
                PCurrentTime = currenttime,
                UserId = userId,
                UserEmailC = userem
                
            };

            this.data.Posts.Add(postdt);
            this.data.SaveChanges();

            return postdt.Id;
        }

        public bool Delete(int id)
        {
            var post = this.data.Posts.Find(id);

            this.data.Posts.Remove(post);
            this.data.SaveChanges();

            return true;
        }

        public bool Edit(int id, string ptopic,string datacurrent, string description)
        {
            var postda = this.data.Posts.Find(id);

            postda.PostTopic = ptopic;       
            postda.PCurrentTime = datacurrent;
            postda.PostContent = description;

            this.data.SaveChanges();

            return true;
        }

        public PostQueryServiceModel UsersPosts(int currentpage, int storiesper, string userId)
        {

            var postquery = this.data.Posts.AsQueryable();

            var totstor = postquery.Count();


            var data = postquery
                .Skip((currentpage - 1) * storiesper)
                .Take(storiesper)
                .OrderBy(x => x.Id)
                .Where(x => x.UserId == userId)
                .Select(s => new PostServiceModel
                {
                    Id = s.Id,
                    PostTopic = s.PostTopic,
                    PostContent = s.PostContent,
                    PCurrentTime = s.PCurrentTime,                
                    UserEmailC = s.UserEmailC

                })
                .ToList();



            return new PostQueryServiceModel
            {
                TotalPosts = totstor,
                CurrentPage = currentpage,
                PostsPerPage = storiesper,
                Posts = data,
            };

        }
    }
}
