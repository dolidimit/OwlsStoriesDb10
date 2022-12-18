using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Favourites
{
    public class FavouritesQueryServiceModel
    {

        public int FavBooksPerPage { get; init; }

        public string FavTopic { get; init; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public string Genre { get; init; }

        public IEnumerable<string> Genres { get; set; }

        public int CurrentPage { get; init; }

        public int TotalFavBooks { get; set; }

        public IEnumerable<FavouritesServiceModel> FavBooks { get; set; }

    }
}
