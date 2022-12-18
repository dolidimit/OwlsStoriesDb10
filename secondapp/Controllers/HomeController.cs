using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using secondapp.Data;
using secondapp.Models;
using secondapp.Models.Books;
using secondapp.Services.Books;
using System.Diagnostics;

namespace secondapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService books;
        private readonly BookAppDbContext data;

        public HomeController(BookAppDbContext data, ILogger<HomeController> logger,IBookService books)
        {
            this.data = data;
            _logger = logger;
            this.books = books;
        }

 
        public IActionResult Index([FromQuery]AllQueryBooksModel query)
        {

            var datast = this.books.AllBooksHome(
            AllQueryBooksModel.BooksPerPage);

            query.TotalBooks = datast.TotalBooks;
            query.Books = datast.Books;

            return View(query);
               
        }

        public IActionResult Info()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
