using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Posts
{
    public class PostQueryServiceModel
    {

        public int PostsPerPage { get; init; }

        public int CurrentPage { get; init; } 

        public int TotalPosts { get; set; }

        public IEnumerable<PostServiceModel> Posts { get; set; }

    }
}
