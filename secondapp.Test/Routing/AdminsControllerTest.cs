using MyTested.AspNetCore.Mvc;
using secondapp.Controllers;
using secondapp.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace secondapp.Test.Routing
{
    public class AdminsControllerTest
    {
        [Fact]
        public void AdminssPublicStoriesPageRoute()
        => MyRouting
          .Configuration()
           .ShouldMap("/Admins/PublicStories")
          .To<AdminsController>(c => c.PublicStories(With.Any<AdminQueryModel>()));

        [Fact]
        public void AdminssAllStoriesPageRoute()
       => MyRouting
         .Configuration()
          .ShouldMap("/Admins/AllStories")
         .To<AdminsController>(c => c.AllStories(With.Any<AdminQueryModel>()));


        [Fact]
        public void AdminssPublicStoriesUserPageRoute()
           => MyRouting
        .Configuration()
         .ShouldMap("/Admins/PublicStoriesUser")
        .To<AdminsController>(c => c.PublicStoriesUser(With.Any<AdminQueryModel>()));

        [Fact]
        public void AdminsAllPostsPageRoute()
          => MyRouting
       .Configuration()
        .ShouldMap("/Admins/AllPosts")
       .To<AdminsController>(c => c.AllPosts(With.Any<AdminQueryModel>()));

        [Fact]
        public void AdminsPublicBooksPageRoute()
          => MyRouting
       .Configuration()
        .ShouldMap("/Admins/PublicBooks")
       .To<AdminsController>(c => c.PublicBooks(With.Any<AdminQueryModel>()));



    }
}
