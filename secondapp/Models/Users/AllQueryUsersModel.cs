using secondapp.Services.Posts;
using secondapp.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Models.Users
{
    public class AllQueryUsersModel
    {

        public const int StoriesPerBookPage = 1;


        public const int StoriesPerUsersPage = 100;


        public const int PostsPerUsersPage = int.MaxValue;


        public const int PublicStoriesPerUsersPage = 2;


        public const int AllUsersStoriesPerPage = 200;

        public string Topic { get; init; }

        public string Genre { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalBookStories { get; set; }

        public int TotalFavourites { get; set; }

        public int TotalUsersPosts { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Topics { get; set; }

        public IEnumerable<UsersDataServiceModel> BookStories { get; set; }

        public IEnumerable<UsersDataServiceModel> UsersStories { get; set; }

        public IEnumerable<UsersDataServiceModel> SharedStories { get; set; }

        public IEnumerable<UsersDataServiceModel> AllPublStories { get; set; }

        public IEnumerable<UsersDataServiceModel> UsersPosts { get; set; }

        public IEnumerable<UsersDataServiceModel> UsersFavourites { get; set; }


    }
}
