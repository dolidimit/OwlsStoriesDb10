using secondapp.Services.Admin;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Models.Admin
{
    public class AdminQueryModel
    {
        public const int BooksPerPage = 25;

        public const int StoriesPerPage = 25;

        public const int ItemsPerPage = 50;

        public const int EventsPerPage = 5;

        public const int EventsPerPageAdmin = 50;

        public string Topic { get; init; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalBooks { get; set; }

        public int TotalPosts { get; set; }

        public int TotalStories { get; set; }

        public int TotalEvents { get; set; }

        public int GenreId { get; init; }

        public IEnumerable<AdminServiceModel> Books { get; set; }

        public IEnumerable<AdminServiceModel>  Stories { get; set; }

        public IEnumerable<AdminEventServiceModel> Events { get; set; }

        public IEnumerable<AdminPostServiceModel> Posts { get; set; }
    }
}
