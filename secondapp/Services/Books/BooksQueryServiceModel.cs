using System.Collections.Generic;

namespace secondapp.Services.Books
{
    public class BooksQueryServiceModel
    {

        public int BooksStPerPage { get; init; } 

        public int CurrentPage { get; init; }

        public int TotalBooks { get; init; }

        public IEnumerable<BooksServiceModel> Books { get; init; }

    }
}
