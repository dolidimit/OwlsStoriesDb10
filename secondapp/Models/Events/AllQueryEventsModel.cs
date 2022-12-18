using secondapp.Services.Events;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Models.Events
{
    public class AllQueryEventsModel
    {
        public const int EventsPerPage = 5;

        public const int EventsPerPageAdmin = 50;

        public int CurrentPage { get; init; } = 1;

        public int TotalEvents { get; set; }

        public IEnumerable<EventsServiceModel> Events { get; set; }

    }
}
