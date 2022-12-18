using secondapp.Data.Models;
using secondapp.Models.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Favourites
{
    public class FavouritesServiceModel
    {
        public int Id { get; set; }

        public string FavTitle { get; set; }

        public string FavTopic { get; set; }

        public string FavImgUrl { get; set; }

        public string FavUserAuthor { get; set; }

        public string FavCon { get; set; }

        public int FavPages { get; set; }

        public string FavBookLink { get; set; }

        public string FavBookPdf { get; set; }

    }
}
