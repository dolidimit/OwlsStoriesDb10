using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Events
{
    public class EventsQueryServiceModel
    {

        public int EventsPerPage { get; init; }

        public int EventsPerPageAdmin { get; init; }

        public int CurrentPage { get; init; }

        public int TotalEvents { get; set; }

        public IEnumerable<EventsServiceModel> Events { get; set; }
    }
}
