using secondapp.Models.Admin;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Services.Admin
{
    public class AdminQueryServiceModel
    {
        public int ItemsPerPage { get; init; }

        public int EventsPerPageAdmin { get; init; }

        public int CurrentPage { get; init; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int TotalPosts { get; init; }

        public int TotalBooks { get; init; }

        public int TotalStories { get; init; }

        public int TotalEvents { get; init; }

        public IEnumerable<AdminServiceModel> Stories { get; init; }

        public IEnumerable<AdminServiceModel> Books { get; init; }

        public IEnumerable<AdminEventServiceModel> Events { get; init; }

        public IEnumerable<AdminPostServiceModel> Posts { get; init; }

    }
}
