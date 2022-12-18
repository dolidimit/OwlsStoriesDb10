using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Services.Admin
{
    public class AdminBookServiceModel : AdminServiceModel
    {
        public int GenreId { get; init; }

        public string Genre { get; init; }

        public string Topic { get; init; }

        public int Pages { get; init; }

        public string Author { get; init; }

        [Display(Name = "Choose Pdf file")]
        [Required]
        public IFormFile BookPdfFil { get; set; }
        public string BookPdf { get; set; }

        public string BookLinkDw { get; init; }
    }
}
