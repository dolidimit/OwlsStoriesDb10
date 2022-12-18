using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Services.Posts
{
    public interface IPostsService
    {

        PostQueryServiceModel AllPosts(
             int currentpage,
           int storiesper);

        PostQueryServiceModel UsersPosts(
          int currentpage,
        int storiesper,
        string userId);


        bool Delete(int id);

        int Create(
            string ptopic,    
            string datacurrent,
            string description,
            string userId,
            string userem           
            );


        bool Edit(
            int id,         
            string ptopic,          
            string datacurrent,
            string description        
            );





    }
}
