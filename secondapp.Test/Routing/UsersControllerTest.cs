using MyTested.AspNetCore.Mvc;
using secondapp.Controllers;
using secondapp.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace secondapp.Test.Routing
{
    public class UsersControllerTest
    {

        [Fact]
        public void UsersIndexPageRoute()
        => MyRouting
        .Configuration()
        .ShouldMap("/Users/")
        .To<UsersController>(c => c.Index(With.Any<AllQueryUsersModel>()));

        [Fact]
        public void UsersBookStoriesPageRoute()
        => MyRouting
        .Configuration()
        .ShouldMap("/Users/BookStories")
        .To<UsersController>(c => c.BookStories(With.Any<AllQueryUsersModel>()));





    }
}
