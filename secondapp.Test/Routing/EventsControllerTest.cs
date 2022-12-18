using MyTested.AspNetCore.Mvc;
using secondapp.Controllers;
using secondapp.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace secondapp.Test.Routing
{
    public class EventsControllerTest
    {
        [Fact]
        public void EventsAddBookPageRoute()
          => MyRouting
              .Configuration()
              .ShouldMap("/Events/Add")
              .To<EventsController>(c => c.Add());
        [Fact]
        public void EventsAddBookDataPageRoute()
           => MyRouting
               .Configuration()
               .ShouldMap("/Events/Add")
               .To<EventsController>(c => c.Add(With.Any<AddEventFormModel>()));

        [Fact]
        public void EventsAddPostFormBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap(request => request
                   .WithPath("/Events/Add")
                   .WithMethod(HttpMethod.Post))
               .To<EventsController>(c => c.Add(With.Any<AddEventFormModel>()));

        [Fact]
        public void EventsEditPostFormBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Events/Edit/20")
                    .WithMethod(HttpMethod.Post))
                .To<EventsController>(c => c.Edit(20));

        [Fact]
        public void EventsAllEventsPageRoute()
           => MyRouting
             .Configuration()
              .ShouldMap("/Events/AllEvents")
             .To<EventsController>(c => c.AllEvents(With.Any<AllQueryEventsModel>()));


        [Fact]
        public void EventsPublicEventsPageRoute()
          => MyRouting
            .Configuration()
             .ShouldMap("/Events/PublicEvents")
            .To<EventsController>(c => c.PublicEvents(With.Any<AllQueryEventsModel>()));

        [Fact]
        public void EventsPublicEventsUserPageRoute()
         => MyRouting
           .Configuration()
            .ShouldMap("/Events/PublicEventsUser")
           .To<EventsController>(c => c.PublicEventsUser(With.Any<AllQueryEventsModel>()));


    }
}
