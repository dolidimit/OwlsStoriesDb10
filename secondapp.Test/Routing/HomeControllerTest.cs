using MyTested.AspNetCore.Mvc;
using secondapp.Controllers;
using secondapp.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using secondapp.Services.Books;

namespace secondapp.Test.Routing
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexRouteShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/")
                .To<HomeController>(c => c.Index(With.Any<AllQueryBooksModel>()));

        [Fact]
        public void ErrorRouteShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Home/Error")
                .To<HomeController>(c => c.Error());


        
    }
}
