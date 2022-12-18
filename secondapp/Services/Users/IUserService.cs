using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Users
{
    public interface IUserService
    {
        UsersQueryServiceModel BookStories
           (int currentpage, 
            int storiesper,
           string userId);

        UsersQueryServiceModel UsersPosts
          (int currentpage, int storiesper,
          string userId);

        UsersQueryServiceModel UsersFavourites
        (int currentpage, int storiesper,
        string userId);

        UsersQueryServiceModel UsersStories
      (int currentpage, int storiesper,
      string userId);

    }
}
