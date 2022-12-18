using secondapp.Data;
using secondapp.Data.Models;
using System.Linq;

namespace secondapp.Services.Books
{
    
    public class BookService : IBookService
    {
        private readonly BookAppDbContext data;

        public BookService(BookAppDbContext data)
        {
            this.data = data;
        }

        public BooksQueryServiceModel All(string searchterm,int currentpage, int booksperpage)
        {
            var storquery = this.data.Books.AsQueryable();


            if (!string.IsNullOrWhiteSpace(searchterm))
            {
                storquery = storquery.Where(s => (s.Title + " " + s.Topic).ToLower()
                .Contains(searchterm) || s.StoryCon.ToLower().Contains(searchterm.ToLower()));
            }

            var totstor = storquery.Count();

            var data = storquery
                .Skip((currentpage - 1) * booksperpage)
                .Take(booksperpage)
                .OrderBy(x => x.Id)
                .Select(s => new BooksServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageUrl = s.ImageUrl
                })
                .ToList();


            return new BooksQueryServiceModel
            {
                TotalBooks = totstor,
                CurrentPage = currentpage,
                BooksStPerPage = booksperpage,
                Books = data,
            };

        }

        public BooksQueryServiceModel PublicBooks(string searchterm, int currentpage, int booksperpage)
        {
            var storquery = this.data.Books.AsQueryable();


            if (!string.IsNullOrWhiteSpace(searchterm))
            {
                storquery = storquery.Where(s => (s.Title + " " + s.Topic).ToLower()
                .Contains(searchterm) || s.StoryCon.ToLower().Contains(searchterm.ToLower()));
            }

            var totstor = storquery.Count();

            var data = storquery
                .Skip((currentpage - 1) * booksperpage)
                .Take(booksperpage)
                .OrderBy(x => x.Id)
                .Select(s => new BooksServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageUrl = s.ImageUrl
                })
                .ToList();


            return new BooksQueryServiceModel
            {
                TotalBooks = totstor,
                CurrentPage = currentpage,
                BooksStPerPage = booksperpage,
                Books = data,
            };

        }




        public BooksQueryServiceModel AllBooks(int currentpage, int booksperpage)
        {
            var storquery = this.data.Books.AsQueryable();

            var totstor = storquery.Count();

            var data = storquery
                .Skip((currentpage - 1) * booksperpage)
                .Take(booksperpage)
                .OrderBy(x => x.Id)
                .Select(s => new BooksServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageUrl = s.ImageUrl
                })
                .ToList();


            return new BooksQueryServiceModel
            {
                TotalBooks = totstor,
                CurrentPage = currentpage,
                BooksStPerPage = booksperpage,
                Books = data,
            };

        }

        public int Create(string title,string rtitle,string topic, string imageurl, string author,int pages,
            string description, string booklink, string bookpdf)
        {
            var bookdt = new Book
            {
                Title = title,
                RTitle = rtitle,
                ImageUrl = imageurl,
                Topic = topic,
                Pages = pages,
                Author = author,
                StoryCon = description,
                BookLinkDw = booklink,
                BookPdf = bookpdf
            };

            this.data.Books.Add(bookdt);
            this.data.SaveChanges();

            return bookdt.Id;

        }

        public bool Send(int id)
        {
            var book = this.data.Books.Find(id);

            this.data.Books.Remove(book);
            this.data.SaveChanges();

            return true;
        }

        public BooksServiceModel Details(int id)
         => this.data.Books.Where(x => x.Id == id)
                .Select(x => new BooksServiceModel
                {
                    Title = x.Title,
                    RTitle = x.RTitle,
                    Topic = x.Topic,
                    ImageUrl = x.ImageUrl,
                    Author = x.Author,
                    Pages = x.Pages,
                    StoryCon = x.StoryCon,
                    BookLinkDw = x.BookLinkDw,
                    BookPdf = x.BookPdf
                })
                .FirstOrDefault();

        
        public bool Edit(int id, string title, string rtitle,string topic, string imageurl, string author,
            int pages, string description,string booklink,string bookpdf)
        {
            var storyda = this.data.Books.Find(id);

            storyda.Title = title;
            storyda.RTitle = rtitle;
            storyda.Topic = topic;
            storyda.ImageUrl = imageurl;
            storyda.Author = author;
            storyda.Pages = pages;
            storyda.StoryCon = description;
            storyda.BookLinkDw = booklink;
            storyda.BookPdf = bookpdf;

            this.data.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var book = this.data.Books.Find(id);

            this.data.Books.Remove(book);
            this.data.SaveChanges();

            return true;
        }

        public BooksQueryServiceModel AllBooksHome(int booksperpage)
        {
            var storquery = this.data.Books.AsQueryable();

            var totstor = storquery.Count();

            var data = storquery
                .Take(booksperpage)
                .OrderBy(x => x.Id)
                .Select(s => new BooksServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageUrl = s.ImageUrl
                })
                .Take(6)
                .ToList();


            return new BooksQueryServiceModel
            {
                TotalBooks = totstor,
                BooksStPerPage = booksperpage,
                Books = data,
            };
        }

        

    }
}
