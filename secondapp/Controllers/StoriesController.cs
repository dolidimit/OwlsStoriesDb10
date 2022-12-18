using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using secondapp.Data;
using secondapp.Models.Stories;
using secondapp.Services.Stories;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace secondapp.Controllers
{
    [Authorize]
    public class StoriesController : Controller
    {

        private readonly IStoryService stories;
        private readonly BookAppDbContext data;

        public StoriesController(IStoryService stories,BookAppDbContext data)
        {
            this.stories = stories;
            this.data = data;
        }

        
        public IActionResult Add() => View(new AddStoryFormModel
        {
            Genres = this.GetGenres()
        });


        [HttpPost]
        
        public IActionResult Add(AddStoryFormModel storym)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            if (!this.data.Genres.Any(g => g.Id == storym.GenreId))
            {
                this.ModelState.AddModelError(nameof(storym.GenreId), "Genre does not exist.");
            }


            if (!ModelState.IsValid)
            {
                storym.Genres = this.GetGenres();

                return View(storym);
            }

            this.stories.Create(
                storym.Title,
                storym.GenreId,
                storym.Topic,
                storym.ImageUrl,
                storym.Pseudonym,
                storym.Age,
                storym.Public,
                storym.StoryText,
                userId
                );

            return RedirectToAction(nameof(AllMine));

        }


        public IActionResult Details(int id)
        {
            var story = this.stories.Details(id);

            return View(story);
        }

        public IActionResult Edit(int id)
        {
            var storycur = this.stories.Details(id);

            return View(new AddStoryFormModel
            {
                Title = storycur.Title,
                ImageUrl = storycur.ImageUrl,
                Topic = storycur.Topic,
                GenreId = storycur.GenreId,
                Genres = this.GetGenres(),
                Age = storycur.Age,
                Pseudonym = storycur.Pseudonym,
                Public = storycur.Public,
                StoryText = storycur.StoryText
            });


        }


        [HttpPost]
        public IActionResult Edit(int id,AddStoryFormModel storm)
        {
         
            var storyed = this.stories.Edit(
                id,
                storm.Title,
                storm.GenreId,
                storm.Topic,
                storm.ImageUrl,
                storm.Pseudonym,
                storm.Age,
                storm.Public,
                storm.StoryText);

            if(!storyed)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllMine));
        }

   
        public IActionResult Delete(int id)
        {
           
            var storyd = this.stories.Delete(id);

            if(!storyd)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllMine));
        }


        public IActionResult AllMine([FromQuery]AllQueryStoriesModel query)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            var storiespl = this.stories.AllMine(
            query.SearchTerm,
            query.CurrentPage,
            AllQueryStoriesModel.StoriesPerPage,
            userId);

            query.TotalStories = storiespl.TotalStories;
            query.Stories = storiespl.Stories;


            return View(query);

        }

 
        public IActionResult SendUsersBook()
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            this.stories.SendUsersBook(userId);


            return RedirectToAction(nameof(AllMine));

        }


        private IEnumerable<StoryGenreModel> GetGenres()
            => this.data
            .Genres
            .Select(x => new StoryGenreModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();



    }
}
