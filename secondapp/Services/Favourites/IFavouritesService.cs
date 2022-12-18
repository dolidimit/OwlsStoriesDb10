using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Favourites
{
    public interface IFavouritesService
    {

        bool Save(int id,string title, string topic,string imgurl,
            string psedonym, string favcon,string userId);

        bool SaveBook(int id, string title, string topic, string imgurl,
          string psedonym, string favcon, int fpages, string bookl, string bookpdf, string userId);

        bool Delete(int id);

        FavouritesServiceModel Details(int id);


        FavouritesQueryServiceModel All
          (int currentpage,
          int storiesper,
          string userId);

    }
}
