using Microsoft.AspNetCore.Http;
using secondapp.Data.Models;
using secondapp.Models.Stories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Models.Favourites
{
    public class AddFavouriteModel
    {

        [Required]
        [MaxLength(25)]
        public string FavTitle { get; set; }

        [Required]
        [MaxLength(20)]
        public string FavTopic { get; set; }

        [Url]
        public string FavImgUrl { get; set; }

        [Required]
        [MaxLength(25)]
        public string FavUserAuthor { get; set; }

        public string UserId { get; set; }

        [Required]
        [MaxLength(8097)]
        public string FavCon { get; set; }

        public int FavPages { get; set; }

        public string FavBookLink { get; set; }

        public string FavBookPdf { get; set; }

    }
}
