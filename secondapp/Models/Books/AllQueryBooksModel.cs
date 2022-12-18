using secondapp.Services.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Models.Books
{
    public class AllQueryBooksModel
    {
        public const int BooksPerPage = 24;

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalBooks { get; set; }
        public IEnumerable<BooksServiceModel> Books { get; set; }

    }
}
