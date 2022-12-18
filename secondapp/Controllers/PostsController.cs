using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using secondapp.Data;
using secondapp.Models.Posts;
using secondapp.Services.Posts;
using System;
using System.Linq;
using System.Security.Claims;

namespace secondapp.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IPostsService posts;
        private readonly BookAppDbContext data;

        public PostsController(BookAppDbContext data, IPostsService posts)
        {
            this.data = data;
            this.posts = posts;
        }

    
        public IActionResult AddPost() => View();
    
        [HttpPost]
        public IActionResult AddPost(AddPostFormModel postm)
        {

            if (!ModelState.IsValid)
            {
                return View(postm);
            }

            var useremail = this.User.FindFirst(ClaimTypes.Email).Value;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var currenttime = DateTime.Now.ToString("dd-MM-yyyy h:mm:ss tt");

            this.posts.Create(
                postm.PostTopic,            
                postm.PCurrentTime,
                postm.PostContent,
                postm.UserId = userId,
                postm.UserEmailC = useremail
               
                );

            return RedirectToAction(nameof(AllPosts));

        }


        public IActionResult Delete(int id)
        {

            var postd = this.posts.Delete(id);

            if (!postd)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllPosts));

        }


        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            var postcu = this.data.Posts.Where(x => x.Id == id).FirstOrDefault();

            return View(new AddPostFormModel
            {
                PostTopic = postcu.PostTopic,            
                PCurrentTime = postcu.PCurrentTime,
                PostContent = postcu.PostContent
            });


        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, AddPostFormModel postm)
        {

            var posted = this.posts.Edit(
                id,
                postm.PostTopic,          
                postm.PCurrentTime,
                postm.PostContent);

            if (!posted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllPosts));
        }


       
        public IActionResult AllPosts([FromQuery] AllQueryPostsModel query)
        {
            var postsspl = this.posts.AllPosts(
           query.CurrentPage,
           AllQueryPostsModel.PostsPerPage);

            query.TotalPosts = postsspl.TotalPosts;
            query.Posts = postsspl.Posts;


            return View(query);
    
        }


        public IActionResult UsersPosts([FromQuery] AllQueryPostsModel query)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var postsspl = this.posts.UsersPosts(
             query.CurrentPage,
             AllQueryPostsModel.PostsPerPage,
             userId);

            query.TotalPosts = postsspl.TotalPosts;
            query.Posts = postsspl.Posts;


            return View(query);

        }

    }
}
