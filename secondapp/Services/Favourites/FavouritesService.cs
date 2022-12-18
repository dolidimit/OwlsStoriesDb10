using secondapp.Data;
using secondapp.Data.Models;
using System.Linq;


namespace secondapp.Services.Favourites
{
    public class FavouritesService : IFavouritesService
    {
        private readonly BookAppDbContext data;

        public FavouritesService(BookAppDbContext data)
        {
            this.data = data;
        }

        public bool Save(int id,string title,string imgurl,string topic,string psedonym,string favcon, string userId)
        {

            var story = this.data.Stories.Where(x => x.Id == id).FirstOrDefault();

            var favourite = this.data.FavouriteItems.Where(x => x.FavTitle == story.Title && x.UserId == userId).FirstOrDefault();


            if (favourite==null)
            {
                var favbook = new FavouriteItem
                {
                    FavTitle = story.Title,
                    FavTopic = story.Topic,
                    FavImgUrl = story.ImageUrl,
                    FavUserAuthor = story.Pseudonym,
                    FavCon = story.StoryText,
                    UserId = userId
                };

                this.data.FavouriteItems.Add(favbook);
                this.data.SaveChanges();
            }

           
            return true;
        }


        public FavouritesQueryServiceModel All(int currentpage, int storiesper, string userId)
        {
            var favquery = this.data.FavouriteItems.Where(x=> x.UserId == userId).AsQueryable();


            var totfav = favquery.Count();

            var favourites = favquery
                .Skip((currentpage - 1) * storiesper)
                .Take(storiesper)
                 .OrderBy(x => x.Id)
                .Select(s => new FavouritesServiceModel
                {
                    Id = s.Id,
                    FavTitle = s.FavTitle,
                    FavCon = s.FavCon,
                    FavImgUrl = s.FavImgUrl,
                    FavBookLink = s.FavBookLink
                })
                .ToList();


            return new FavouritesQueryServiceModel
            {
                TotalFavBooks = totfav,
                CurrentPage = currentpage,
                FavBooksPerPage = storiesper,
                FavBooks = favourites
            };
        }

        public bool Delete(int id)
        {
            var favstory = this.data.FavouriteItems.Where(x => x.Id == id).FirstOrDefault();

           
            this.data.FavouriteItems.Remove(favstory);
            this.data.SaveChanges();

            return true;
        }

        public FavouritesServiceModel Details(int id)
        => this.data.FavouriteItems.Where(x => x.Id == id)
                .Select(x => new FavouritesServiceModel
                {
                    Id = x.Id,
                    FavTitle = x.FavTitle,
                    FavTopic = x.FavTopic,
                    FavImgUrl = x.FavImgUrl,
                    FavUserAuthor = x.FavUserAuthor,              
                    FavCon = x.FavCon,
                    FavPages = x.FavPages,
                    FavBookLink = x.FavBookLink,
                    FavBookPdf = x.FavBookPdf
                })
                .FirstOrDefault();

      

        public bool SaveBook(int id, string title, string topic, string imgurl, string psedonym, 
            string favcon,int fpages,string bookl,string bookpdf,string userId)
        {
            var book = this.data.Books.Where(x => x.Id == id).FirstOrDefault();

            var favourite = this.data.FavouriteItems.Where(x => x.FavTitle == book.Title && x.UserId == userId).FirstOrDefault();


            if (favourite == null)
            {
                var favbook = new FavouriteItem
                {
                    FavTitle = book.Title,
                    FavTopic = book.Topic,
                    FavImgUrl = book.ImageUrl,
                    FavUserAuthor = book.Author,
                    FavCon = book.StoryCon,
                    FavPages = book.Pages,
                    FavBookLink = book.BookLinkDw,
                    FavBookPdf = book.BookPdf,
                    UserId = userId
                };

                this.data.FavouriteItems.Add(favbook);
                this.data.SaveChanges();
            }


            return true;
        }


    }
}
