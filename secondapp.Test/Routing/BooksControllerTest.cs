using MyTested.AspNetCore.Mvc;
using secondapp.Controllers;
using secondapp.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace secondapp.Test.Routing
{
    public class BooksControllerTest
    {
        [Fact]
        public void BooksAddBookPageRoute()
           => MyRouting
               .Configuration()
               .ShouldMap("/Books/Add")
               .To<BooksController>(c => c.Add());

        [Fact]
        public void BookAddPostFormBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Books/Add")
                    .WithMethod(HttpMethod.Post))
                .To<BooksController>(c => c.Add(With.Any<AddBookFormModel>()));

        [Fact]
        public void BookEditPostFormBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Books/Edit/27")
                    .WithMethod(HttpMethod.Post))
                .To<BooksController>(c => c.Edit(27,With.Any<AddBookFormModel>()));

        [Fact]
        public void BooksAddBookDataPageRoute()
           => MyRouting
               .Configuration()
               .ShouldMap("/Books/Add")
               .To<BooksController>(c => c.Add(With.Any<AddBookFormModel>()));

        [Fact]
        public void BooksAllBooksDataPageRoute()
           => MyRouting
               .Configuration()
               .ShouldMap("/Books/All")
               .To<BooksController>(c => c.All(With.Any<AllQueryBooksModel>()));


        [Fact]
        public void BooksAllBooksAdminDataPageRoute()
           => MyRouting
               .Configuration()
               .ShouldMap("/Books/AllBooks")
               .To<BooksController>(c => c.AllBooks(With.Any<AllQueryBooksModel>()));

        [Fact]
        public void BooksPublicBooksAdminDataPageRoute()
          => MyRouting
              .Configuration()
              .ShouldMap("/Books/PublicBooks")
              .To<BooksController>(c => c.PublicBooks(With.Any<AllQueryBooksModel>()));

        





    }
}
