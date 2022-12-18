using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Events
{
    public class EventsServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string BookTitle { get; set; }

        public string GuestAuthor { get; set; }

        public string GuestAuthorImage { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Date { get; set; }

        public string ImageUrl { get; set; }

        public int BookStock { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string BookResume { get; set; }

        public IFormFile BookPdfFil { get; set; }

        public string BookPdf { get; set; }

        public string BookLinkDw { get; set; }

        public int UsersCounter { get; set; }
    }
}
