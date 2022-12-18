using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Data.Models
{
    public class EventUser
    {
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }

    }
}
