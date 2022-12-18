using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using secondapp.Data;
using secondapp.Models.Users;
using secondapp.Services.Users;
using System.Security.Claims;


namespace secondapp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService usersdt;
        private readonly BookAppDbContext data;

        public UsersController(IUserService usersdt, BookAppDbContext data)
        {
            this.usersdt = usersdt;
            this.data = data;
        }


        public IActionResult Index([FromQuery] AllQueryUsersModel query)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            var storiespbook = this.usersdt.UsersStories(
            query.CurrentPage,
            AllQueryUsersModel.StoriesPerUsersPage,
            userId);

            var postspo = this.usersdt.UsersPosts(
            query.CurrentPage,
            AllQueryUsersModel.PostsPerUsersPage,
            userId);

            var favourites = this.usersdt.UsersFavourites(
           query.CurrentPage,
           AllQueryUsersModel.AllUsersStoriesPerPage,
           userId);


            query.TotalBookStories = storiespbook.TotalBookStories;
            query.UsersStories = storiespbook.UsersStories;

            query.TotalUsersPosts = postspo.TotalUsersPosts;
            query.UsersPosts = postspo.UsersPosts;

            query.TotalFavourites= favourites.TotalFavourites;
            query.UsersFavourites = favourites.UsersFavourites;
            


            return View(query);
        }

        public IActionResult BookStories([FromQuery] AllQueryUsersModel query)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            var storiespbook = this.usersdt.BookStories(
            query.CurrentPage,
            AllQueryUsersModel.StoriesPerBookPage,
            userId);

            query.TotalBookStories = storiespbook.TotalBookStories;
            query.BookStories = storiespbook.BookStories;


            return View(query);
        }






    }
}
