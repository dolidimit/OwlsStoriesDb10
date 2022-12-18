using MyTested.AspNetCore.Mvc;
using secondapp.Controllers;
using secondapp.Models.Favourites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace secondapp.Test.Routing
{
    public class FavouritesControllerTest
    {
        [Fact]
        public void FavouritesAllPageRoute()
           => MyRouting
               .Configuration()
               .ShouldMap("/Favourites/All")
               .To<FavouritesController>(c => c.All(With.Any<AllQueryFavouritesModel>()));

    }
}
