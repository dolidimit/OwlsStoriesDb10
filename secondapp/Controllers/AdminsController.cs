using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using secondapp.Data;
using secondapp.Models.Admin;
using secondapp.Services.Admin;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;


namespace secondapp.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IAdminService datas;
        private readonly BookAppDbContext data;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminsController(IAdminService datas, BookAppDbContext data, IWebHostEnvironment _webHostEnvironment)
        {
            this.datas = datas;
            this.data = data;
            this._webHostEnvironment = _webHostEnvironment;
        }


        public IActionResult PublicStories(AdminQueryModel query)
        {
            
            var booksspl = this.datas.PublicStories(
                query.SearchTerm,
                query.CurrentPage,
                AdminQueryModel.StoriesPerPage);

            query.TotalStories = booksspl.TotalStories;
            query.Stories = booksspl.Stories;

            return View(query);

        }

        public IActionResult PublicStoriesUser(AdminQueryModel query)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var booksspl = this.datas.PublicStoriesUser(
                query.SearchTerm,
                query.CurrentPage,
                AdminQueryModel.StoriesPerPage,userId);

            query.TotalStories = booksspl.TotalStories;
            query.Stories = booksspl.Stories;

            return View(query);

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllStories(AdminQueryModel query)
        {

            var booksspl = this.datas.AllStories(
             query.CurrentPage,
             AdminQueryModel.ItemsPerPage);

             query.TotalStories = booksspl.TotalStories;
             query.Stories = booksspl.Stories;

            return View(query);

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllPosts(AdminQueryModel query)
        {

            var booksspl = this.datas.AllPosts(
           query.CurrentPage,
           AdminQueryModel.ItemsPerPage);

            query.TotalPosts = booksspl.TotalPosts;
            query.Posts = booksspl.Posts;

            return View(query);

        }


        [Authorize(Roles = "Administrator")]
        public IActionResult DetailsStory(int id)
        {
            var story = this.datas.DetailsStory(id);

            return View(story);
        }

        public IActionResult DetailsStoryUser(int id)
        {
            var story = this.datas.DetailsStory(id);

            return View(story);
        }


        [Authorize(Roles = "Administrator")]
        public IActionResult EditStory(int id)
        {
            var storycur = this.datas.DetailsStory(id);

            return View(new AdminAddStoryModel
            {
                Title = storycur.Title,
                ImageUrl = storycur.ImageUrl,
                Topic = storycur.Topic,
                GenreId = storycur.GenreId,
                Genres = this.GetGenres(),
                Pseudonym = storycur.Pseudonym,
                StoryText = storycur.StoryText
            });


        }

     
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult EditStory(int id, AdminAddStoryModel storm)
        {

            var storyed = this.datas.EditStory(
                id,
                storm.Title,
                storm.GenreId,
                storm.Topic,
                storm.ImageUrl,
                storm.Pseudonym,
                storm.StoryText);

            if (!storyed)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllStories));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteStory(int id)
        {
            var bookm = this.datas.DeleteStory(id);

            if (!bookm)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllStories));
        }


        [Authorize(Roles = "Administrator")]
        private IEnumerable<AdminStoryGenreModel> GetGenres()
           => this.data
           .Genres
           .Select(x => new AdminStoryGenreModel
           {
               Id = x.Id,
               Name = x.Name
           })
           .ToList();

    }
}
