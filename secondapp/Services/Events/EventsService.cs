using secondapp.Data;
using secondapp.Data.Models;
using System;
using System.Linq;

namespace secondapp.Services.Events
{
    public class EventsService : IEventService
    {
        private readonly BookAppDbContext data;

        public EventsService(BookAppDbContext data)
        {
            this.data = data;
        }


        public int Create(string title, string subtitle, string booktit, string guestauthor,
            string guesauthimg, string starttime, string endtime, DateTime datab,
            string imageUrl, int bookstock, string adress, string bookres, 
            string description, string bookl, string bookpdf)
        {

            var eventd = new Event
            {
                Title = title,
                SubTitle = subtitle,
                BookTitle = booktit,
                ImageUrl = imageUrl,
                GuestAuthor = guestauthor,
                GuestAuthorImage = guesauthimg,
                StartTime = starttime,
                EndTime = endtime,
                Date = datab,
                BookStock = bookstock,
                Address = adress,
                BookResume = bookres,
                Description = description,
                BookLinkDw = bookl,
                BookPdf = bookpdf
            };

            this.data.Events.Add(eventd);
            this.data.SaveChanges();

            return eventd.Id;
        }

        public bool Delete(int id)
        {
            var eventd = this.data.Events.Find(id);

            this.data.Events.Remove(eventd);
            this.data.SaveChanges();

            return true;
        }

        public EventsServiceModel Details(int id)
        => this.data.Events.Where(x => x.Id == id)
       .Select(x => new EventsServiceModel
       {
           Title = x.Title,
           SubTitle = x.SubTitle,
           BookTitle = x.BookTitle,
           GuestAuthor = x.GuestAuthor,
           GuestAuthorImage = x.GuestAuthorImage,
           ImageUrl = x.ImageUrl,
           Date = x.Date.ToString("dd/MM/yyyy"),
           StartTime = x.StartTime,
           EndTime = x.EndTime,
           BookStock = x.BookStock,
           BookResume = x.BookResume,
           Address = x.Address,
           Description = x.Description,
           BookLinkDw = x.BookLinkDw,
           BookPdf = x.BookPdf
       })
       .FirstOrDefault();


        public EventsServiceModel DetailsUser(int id)
              => this.data.Events.Where(x => x.Id == id)
        .Select(x => new EventsServiceModel
        {
            Title = x.Title,
            SubTitle = x.SubTitle,
            BookTitle = x.BookTitle,
            GuestAuthor = x.GuestAuthor,
            GuestAuthorImage = x.GuestAuthorImage,
            ImageUrl = x.ImageUrl,
            Date = x.Date.ToString("dd/MM/yyyy"),
            StartTime = x.StartTime,
            EndTime = x.EndTime,
            BookStock = x.BookStock,
            BookResume = x.BookResume,
            Address = x.Address,
            Description = x.Description,
            BookLinkDw = x.BookLinkDw,
            BookPdf = x.BookPdf

        })
        .FirstOrDefault();


        public bool Edit(int id, string title, string subtitle, string guestauthor, string starttime, 
            string endtime, DateTime date, string imageUrl, int bookstock, 
            string adress, string description, string bookl, string bookpdf)
        {
            var eventda = this.data.Events.Find(id);

            eventda.Title = title;
            eventda.SubTitle = subtitle;
            eventda.GuestAuthor = guestauthor;
            eventda.StartTime = starttime;
            eventda.EndTime = endtime;
            eventda.Date = date;
            eventda.ImageUrl = imageUrl;
            eventda.BookStock = bookstock;
            eventda.Address = adress;
            eventda.Description = description;
            eventda.BookLinkDw = bookl;
            eventda.BookPdf = bookpdf;



            this.data.SaveChanges();

            return true;
        }


        public bool SendEvent(int id, string userId)
        {
            var eventbval = this.data.EventUsers.Where(x => x.EventId == id && x.UserId == userId).FirstOrDefault();
            var eventb = this.data.Events.Where(x => x.Id == id).FirstOrDefault();
            var user = this.data.Users.Where(x => x.Id == userId).FirstOrDefault();

            if (eventbval == null)
            {
                var eventuser = new EventUser
                {
                    EventId = id,
                    Event = eventb,
                    UserId = userId,
                    User = user
                };

                eventb.EventsUsers.Add(eventuser);

                var usersc = this.data.Events.Where(x => x.Id == id).FirstOrDefault();


                this.data.EventUsers.Add(eventuser);
                var users = this.data.EventUsers.Where(x => x.EventId == id).Count();
                eventb.UsersCounter = users + 1;
                this.data.SaveChanges();
          
            }


            return true;
        }

        public EventsQueryServiceModel PublicEvents(int currentpage, int itemssperpage)
        {
            var storquery = this.data.Events.AsQueryable();

            var data = storquery
                .Skip((currentpage - 1) * itemssperpage)
                .Take(itemssperpage)
                .OrderByDescending(x => x.Date)
                .Select(s => new EventsServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    SubTitle = s.SubTitle,
                    ImageUrl = s.ImageUrl,
                    GuestAuthor = s.GuestAuthor,
                    Description = s.Description,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Date = s.Date.ToString("dd/MM/yyyy"),
                    BookLinkDw = s.BookLinkDw,
                    BookPdf = s.BookPdf,
                    UsersCounter = s.UsersCounter
                })
                .ToList();

            var totstor = storquery.Count();


            return new EventsQueryServiceModel
            {
                TotalEvents = totstor,
                CurrentPage = currentpage,
                Events = data,
            };
        }

        public EventsQueryServiceModel PublicEventsUser(int currentpage, int itemssperpage)
        {
            var storquery = this.data.Events.AsQueryable();

            var data = storquery
                .Skip((currentpage - 1) * itemssperpage)
                .Take(itemssperpage)
                .OrderByDescending(x => x.Date)
                .Select(s => new EventsServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    SubTitle = s.SubTitle,
                    ImageUrl = s.ImageUrl,
                    GuestAuthor = s.GuestAuthor,
                    Description = s.Description,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Date = s.Date.ToString("dd/MM/yyyy"),
                    BookLinkDw = s.BookLinkDw,
                    BookPdf = s.BookPdf,
                    UsersCounter = s.UsersCounter
                })
                .ToList();

            var totstor = storquery.Count();


            return new EventsQueryServiceModel
            {
                TotalEvents = totstor,
                CurrentPage = currentpage,
                Events = data,
            };
        }


        public EventsQueryServiceModel AllEvents(int currentpage, int itemssperpage)
        {
            var storquery = this.data.Events.AsQueryable();

            var data = storquery
                .Skip((currentpage - 1) * itemssperpage)
                .Take(itemssperpage)
                .OrderBy(x => x.Id)
                .Select(s => new EventsServiceModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    SubTitle = s.SubTitle,
                    ImageUrl = s.ImageUrl,
                    GuestAuthor = s.GuestAuthor,
                    Description = s.Description,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Date = s.Date.ToString("dd/MM/yyyy"),
                    BookLinkDw = s.BookLinkDw,
                    BookPdf = s.BookPdf
                })
                .ToList();

            var totstor = storquery.Count();


            return new EventsQueryServiceModel
            {
                TotalEvents = totstor,
                CurrentPage = currentpage,
                Events = data,
            };

        }


    }
}
