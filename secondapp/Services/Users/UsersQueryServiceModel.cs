using secondapp.Services.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Users
{
    public class UsersQueryServiceModel
    {
        public int StoriesPerBookPage { get; init; }

        public int StoriesPerUsersPage { get; init; }

        public int FavouritesPerUsersPage { get; init; }

        public int PostsPerUsersPage  { get; init; }

        public int PublicStoriesPerUsersPage { get; init; }

        public int AllUsersStoriesPerPage { get; init; }

        public int CurrentPage { get; init; }

        public int TotalBookStories { get; init; }

        public int TotalFavourites { get; init; }

        public int TotalUsersPosts { get; init; }

        public IEnumerable<UsersDataServiceModel> BookStories { get; init; }

        public IEnumerable<UsersDataServiceModel> UsersStories { get; init; }

        public IEnumerable<UsersDataServiceModel> SharedStories { get; init; }

        public IEnumerable<UsersDataServiceModel> AllPublStories { get; init; }

        public IEnumerable<UsersDataServiceModel> UsersPosts { get; set; }

        public IEnumerable<UsersDataServiceModel> UsersFavourites { get; set; }

    }
}
