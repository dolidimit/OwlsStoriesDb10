using Microsoft.AspNetCore.Http;

namespace secondapp.Services.Books
{
    public class BooksServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string RTitle { get; init; }

        public string ImageUrl { get; init; }

        public string UserId { get; init; }

        public string Topic { get; init; }

        public IFormFile BookPdfFil { get; set; }

        public string BookPdf { get; set; }

        public string Author { get; init; }

        public int Pages { get; init; }

        public string StoryText { get; init; }

        public string StoryCon { get; init; }

        public string BookLinkDw { get; set; }



    }
}
