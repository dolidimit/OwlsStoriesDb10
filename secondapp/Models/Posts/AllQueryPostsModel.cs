using secondapp.Services.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Models.Posts
{
    public class AllQueryPostsModel
    {
        public const int PostsPerPage = 9;

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalPosts { get; set; }

        public IEnumerable<PostServiceModel> Posts { get; set; }

    }
}
