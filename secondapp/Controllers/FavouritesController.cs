using Microsoft.AspNetCore.Mvc;
using secondapp.Data;
using secondapp.Models.Favourites;
using secondapp.Services.Favourites;
using System.Linq;
using System.Security.Claims;


namespace secondapp.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly IFavouritesService favouris;
        private readonly BookAppDbContext data;

        public FavouritesController(IFavouritesService favouris, BookAppDbContext data)
        {
            this.favouris = favouris;
            this.data = data;
        }

        [HttpPost]
        public IActionResult Save(int id, AddFavouriteModel postm)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var storyidd = this.data.Stories.Where(x => x.Id == id).FirstOrDefault();

            this.favouris.Save(
                id,
                postm.FavTitle = storyidd.Title,
                postm.FavTopic = storyidd.Topic,
                postm.FavImgUrl = storyidd.ImageUrl,
                postm.FavUserAuthor = storyidd.Pseudonym,
                postm.FavCon = storyidd.StoryText,
                postm.UserId = userId
                
                );

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public IActionResult SaveBook(int id, AddFavouriteModel postm)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var storyidd = this.data.Books.Where(x => x.Id == id).FirstOrDefault();

            this.favouris.SaveBook(
                id,
                postm.FavTitle = storyidd.Title,
                postm.FavTopic = storyidd.Topic,
                postm.FavImgUrl = storyidd.ImageUrl,
                postm.FavUserAuthor = storyidd.Author,
                postm.FavCon = storyidd.StoryCon,
                postm.FavPages = storyidd.Pages,
                postm.FavBookLink = storyidd.BookLinkDw,
                postm.FavBookPdf = storyidd.BookPdf,
                postm.UserId = userId
                );

            return RedirectToAction(nameof(All));
        }

        public IActionResult All([FromQuery] AllQueryFavouritesModel query)
        {

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            var storiespl = this.favouris.All(         
            query.CurrentPage,
            AllQueryFavouritesModel.FavBooksPerPage,
            userId);

            query.TotalFavBooks = storiespl.TotalFavBooks;
            query.FavBooks = storiespl.FavBooks;


            return View(query);

        }


        public IActionResult Delete(int id)
        {
            var bookm = this.favouris.Delete(id);

            return RedirectToAction(nameof(All));
        }


        public IActionResult Details(int id)
        {
            var favstory = this.favouris.Details(id);

            return View(favstory);
        }

    }
}
