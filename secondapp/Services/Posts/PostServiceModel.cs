using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Posts
{
    public class PostServiceModel
    {
        public int Id { get; set; }

        public string PImageUrl { get; set; }

        public string PostTopic { get; set; }

        public string PCurrentTime { get; set; }

        public string UserId { get; set; }


        public string UserEmailC { get; set; }


        public string UserFullNameC { get; set; }

        public string PostContent { get; set; }
    }
}
