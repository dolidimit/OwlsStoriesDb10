using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Events
{
    public interface IEventService
    {
        EventsQueryServiceModel PublicEvents(
       int currentpage,
       int itemssperpage);

        EventsQueryServiceModel PublicEventsUser(
     int currentpage,
     int itemssperpage);

        EventsQueryServiceModel AllEvents(
           int currentpage,
          int itemssperpage);

        EventsServiceModel DetailsUser(int id);

        EventsServiceModel Details(int id);

        bool SendEvent(int id, string userId);

        bool Delete(int id);
        int Create(
           string title,
           string subtitle,
           string booktitle,
           string guestauthor,
           string guesauthimg,
           string starttime,
           string endtime,
           DateTime data,
           string imageUrl,
           int bookstock,
           string adress,
           string bookres,
           string description,
           string booklink,
           string bookpdf
           );

        bool Edit(
            int id,
            string title,
           string subtitle,
           string guestauthor,
           string starttime,
           string endtime,
           DateTime date,
           string imageUrl,
           int bookstock,
           string adress,
           string description,
            string booklink,
           string bookpdf
            );

    }
}
