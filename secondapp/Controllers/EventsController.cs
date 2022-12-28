using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secondapp.Data;
using secondapp.Models.Events;
using secondapp.Services.Events;
using System;
using System.Globalization;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace secondapp.Controllers
{
    public class EventsController : Controller
    {

        private readonly BookAppDbContext data;
        private readonly IEventService datas;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventsController(BookAppDbContext data,IEventService datas, IWebHostEnvironment _webHostEnvironment)
        {
            this.data = data;
            this.datas = datas;
            this._webHostEnvironment = _webHostEnvironment;
        }


        [Authorize(Roles = "Administrator")]
        public IActionResult Add()
        {
            var model = new AddEventFormModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Add(AddEventFormModel eventm)
        {


            if (!ModelState.IsValid)
            {
                return View(eventm);
            }


            string folder = "books/pdf/";
            eventm.BookPdf = await UploadFile(folder, eventm.BookPdfFil);


            this.datas.Create(
                eventm.Title,
                eventm.SubTitle,
                eventm.BookTitle,
                eventm.GuestAuthor,
                eventm.GuestAuthorImage,
                eventm.StartTime,
                eventm.EndTime,
                eventm.Date,
                eventm.ImageUrl,
                eventm.BookStock,
                eventm.Address,
                eventm.BookResume,
                eventm.Description,
                eventm.BookLinkDw,
                eventm.BookPdf
                );

            return RedirectToAction(nameof(AllEvents));

        }

        private async Task<string> UploadFile(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        public IActionResult PublicEvents(AllQueryEventsModel query)
        {

            var booksspl = this.datas.PublicEvents(
           query.CurrentPage,
           AllQueryEventsModel.EventsPerPage);

            query.TotalEvents = booksspl.TotalEvents;
            query.Events = booksspl.Events;

            return View(query);

        }

        public IActionResult PublicEventsUser(AllQueryEventsModel query)
        {

            var booksspl = this.datas.PublicEventsUser(
           query.CurrentPage,
           AllQueryEventsModel.EventsPerPage);

            query.TotalEvents = booksspl.TotalEvents;
            query.Events = booksspl.Events;

            return View(query);

        }


        [Authorize(Roles = "Administrator")]
        public IActionResult AllEvents(AllQueryEventsModel query)
        {

            var booksspl = this.datas.AllEvents(
           query.CurrentPage,
           AllQueryEventsModel.EventsPerPageAdmin);

            query.TotalEvents = booksspl.TotalEvents;
            query.Events = booksspl.Events;

            return View(query);

        }

        public IActionResult DetailsUser(int id)
        {
            var story = this.datas.DetailsUser(id);

            return View(story);
        }

        public IActionResult Details(int id)
        {
            var story = this.datas.Details(id);

            return View(story);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult EditEvent(int id, AddEventFormModel eventm)
        {

            var evented = this.datas.Edit(
                id,
                eventm.Title,
                eventm.SubTitle,
                eventm.GuestAuthor,
                eventm.StartTime,
                eventm.EndTime,
                eventm.Date,
                eventm.ImageUrl,
                eventm.BookStock,
                eventm.Address,
                eventm.Description,
                eventm.BookLinkDw,
                eventm.BookPdf);

            if (!evented)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllEvents));
        }


        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {

            var eventcur = this.datas.DetailsUser(id);

            var eventd = DateTime.ParseExact(
                   eventcur.Date,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);

            return View(new AddEventFormModel
            {
                Title = eventcur.Title,
                SubTitle = eventcur.SubTitle,
                BookTitle = eventcur.BookTitle,
                GuestAuthor = eventcur.GuestAuthor,
                GuestAuthorImage = eventcur.GuestAuthorImage,
                StartTime = eventcur.StartTime,
                EndTime = eventcur.EndTime,
                Date = eventd,
                ImageUrl = eventcur.ImageUrl,
                BookStock = eventcur.BookStock,
                Address = eventcur.Address,
                Description = eventcur.Description,
                BookResume = eventcur.BookResume,
                BookLinkDw = eventcur.BookLinkDw,
                BookPdf = eventcur.BookPdf
            });


        }


        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var bookm = this.datas.Delete(id);

            if (!bookm)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(AllEvents));
        }
        public IActionResult SendEvent(int id, string userId)
        {
            var userid = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.datas.SendEvent(id, userid);

            return RedirectToAction(nameof(PublicEventsUser));
        }




    }
}
