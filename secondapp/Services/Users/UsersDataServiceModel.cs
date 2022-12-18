using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Users
{
    public class UsersDataServiceModel
    {

        public int Id { get; init; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int GenreId { get; set; }

        public string ImageUrl { get; set; }

        public string Topic { get; set; }

        public string Pseudonym { get; set; }

        public int Age { get; set; }

        public string Public { get; set; }

        public int Likes { get; set; }

        public string StoryText { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string PostTopic { get; set; }

        public string PCurrentTime { get; set; }

        public string UserId { get; set; }


        public string UserEmailC { get; set; }


        public string PostContent { get; set; }


    }
}
