using MyTested.AspNetCore.Mvc;
using secondapp.Controllers;
using secondapp.Models.Stories;
using secondapp.Services.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace secondapp.Test.Routing
{
    public class StoriesControllerTest
    {
        [Fact]
        public void StoriesAllMinePageRoute()
            => MyRouting
                .Configuration()
                .ShouldMap("/Stories/AllMine")
                .To<StoriesController>(c => c.AllMine(With.Any<AllQueryStoriesModel>()));


        //[Fact]
        //public void StoriesDetailsPageRoute()
        //    => MyRouting
        //        .Configuration()
        //        .ShouldMap("/Stories/Details")
        //        .To<StoriesController>(c => c.AllMine(With.Any(StoriesServiceModel()));

        [Fact]
        public void StoriesAddStoryPageRoute()
            => MyRouting
                .Configuration()
                .ShouldMap("/Stories/Add")
                .To<StoriesController>(c => c.Add());
        [Fact]
        public void StoriesAddStoryDataPageRoute()
           => MyRouting
               .Configuration()
               .ShouldMap("/Stories/Add")
               .To<StoriesController>(c => c.Add(With.Any<AddStoryFormModel>()));


        [Fact]
        public void StriesAddPostFormBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Stories/Add")
                   .WithMethod(HttpMethod.Post))
               .To<StoriesController>(c => c.Add(With.Any<AddStoryFormModel>()));

        [Fact]
        public void StriesEditPostFormBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Stories/Edit/14")
                    .WithMethod(HttpMethod.Post))
                .To<StoriesController>(c => c.Edit(14, With.Any<AddStoryFormModel>()));





    }
}
