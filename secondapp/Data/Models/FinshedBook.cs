using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Data.Models
{

    public class FinshedBook
    {
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int StoryId { get; set; }


        [ForeignKey(nameof(StoryId))]
        public Story Story { get; set; }

    }
}
