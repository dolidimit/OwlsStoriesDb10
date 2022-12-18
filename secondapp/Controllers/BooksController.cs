using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secondapp.Data;
using secondapp.Models.Books;
using secondapp.Services.Books;
using System;
using System.IO;
using System.Threading.Tasks;


namespace secondapp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService datas;
        private readonly BookAppDbContext data;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BooksController(IBookService datas, BookAppDbContext data, IWebHostEnvironment _webHostEnvironment)
        {
            this.datas = datas;
            this.data = data;
            this._webHostEnvironment = _webHostEnvironment;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Add()
        {
            var model = new AddBookFormModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Add(AddBookFormModel bookm)
        {

            if (!ModelState.IsValid)
            {
                return View(bookm);
            }


            string folder = "books/pdf/";
            bookm.BookPdf = await UploadFile(folder, bookm.BookPdfFil);

            this.datas.Create(
                bookm.Title,
                bookm.RTitle,
                bookm.Topic,
                bookm.ImageUrl,
                bookm.Author,
                bookm.Pages,
                bookm.StoryCon,
                bookm.BookLinkDw,
                bookm.BookPdf
                );

            return RedirectToAction(nameof(PublicBooks));

        }

        private async Task<string> UploadFile(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        public IActionResult All(AllQueryBooksModel query)
        {

            var booksspl = this.datas.All(
                  query.SearchTerm,
           query.CurrentPage,
           AllQueryBooksModel.BooksPerPage);

            query.TotalBooks = booksspl.TotalBooks;
            query.Books = booksspl.Books;

            return View(query);

        }

        public IActionResult PublicBooks(AllQueryBooksModel query)
        {

            var booksspl = this.datas.PublicBooks(
                  query.SearchTerm,
           query.CurrentPage,
           AllQueryBooksModel.BooksPerPage);

            query.TotalBooks = booksspl.TotalBooks;
            query.Books = booksspl.Books;

            return View(query);

        }

        public IActionResult AllBooks(AllQueryBooksModel query)
        {

            var booksspl = this.datas.AllBooks(
           query.CurrentPage,
           AllQueryBooksModel.BooksPerPage);

            query.TotalBooks = booksspl.TotalBooks;
            query.Books = booksspl.Books;

            return View(query);

        }


        public IActionResult Details(int id)
        {
            var book = this.datas.Details(id);

            return View(book);
        }

        public IActionResult DetailsUser(int id)
        {
            var book = this.datas.Details(id);

            return View(book);
        }


        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            var storycur = this.datas.Details(id);

            return View(new AddBookFormModel
            {
                Title = storycur.Title,
                RTitle = storycur.RTitle,
                ImageUrl = storycur.ImageUrl,
                Topic = storycur.Topic,
                Author = storycur.Author,
                Pages = storycur.Pages,
                StoryCon = storycur.StoryCon,
                BookLinkDw = storycur.BookLinkDw,
                BookPdf = storycur.BookPdf
            });


        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id, AddBookFormModel storm)
        {

            var storyed = this.datas.Edit(
                id,
                storm.Title,
                storm.RTitle,
                storm.Topic,
                storm.ImageUrl,
                storm.Author,
                storm.Pages,
                storm.StoryCon,
                storm.BookLinkDw,
                storm.BookPdf);

            if (!storyed)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllBooks));
        }

        public IActionResult Delete(int id)
        {

            var bookd = this.datas.Delete(id);

            if (!bookd)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllBooks));
        }

       
    }
}
