using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Admin
{
    public class AdminPostServiceModel
    {

        public int Id { get; init; }

        public string PImageUrl { get; set; }

        public string PostTopic { get; set; }

        public string PCurrentTime { get; set; }

        public string PostContent { get; set; }

    }
}
