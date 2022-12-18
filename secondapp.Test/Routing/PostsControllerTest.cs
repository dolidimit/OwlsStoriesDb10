using MyTested.AspNetCore.Mvc;
using secondapp.Controllers;
using secondapp.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace secondapp.Test.Routing
{
    public class PostsControllerTest
    {
        [Fact]
        public void PostssAddStoryPageRoute()
           => MyRouting
               .Configuration()
               .ShouldMap("/Posts/AddPost")
               .To<PostsController>(c => c.AddPost());

        [Fact]
        public void PostsAddStoryDataPageRoute()
           => MyRouting
               .Configuration()
               .ShouldMap("/Posts/AddPost")
               .To<PostsController>(c => c.AddPost(With.Any<AddPostFormModel>()));

        [Fact]
        public void PostsAddPostFormBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Posts/AddPost")
                   .WithMethod(HttpMethod.Post))
               .To<PostsController>(c => c.AddPost(With.Any<AddPostFormModel>()));

        [Fact]
        public void PostsEditPostFormBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Posts/Edit/10")
                    .WithMethod(HttpMethod.Post))
                .To<PostsController>(c => c.Edit(10, With.Any<AddPostFormModel>()));

        [Fact]
        public void PostsAllPostsPageRoute()
         => MyRouting
             .Configuration()
             .ShouldMap("/Posts/AllPosts")
             .To<PostsController>(c => c.AllPosts(With.Any<AllQueryPostsModel>()));

        [Fact]
        public void PostsUsersPostsPageRoute()
         => MyRouting
             .Configuration()
             .ShouldMap("/Posts/UsersPosts")
             .To<PostsController>(c => c.UsersPosts(With.Any<AllQueryPostsModel>()));
    }
}
