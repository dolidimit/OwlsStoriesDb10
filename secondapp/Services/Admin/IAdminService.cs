using System;

namespace secondapp.Services.Admin
{
    public interface IAdminService
    {

        AdminQueryServiceModel AllStories(
       int currentpage,
       int itemssperpage);

        AdminQueryServiceModel AllPosts(
        int currentpage,
        int itemssperpage);

        AdminQueryServiceModel PublicBooks(
       int currentpage,
       int itemssperpage);

        AdminQueryServiceModel PublicStories(
             string searchterm,
               int currentpage,
              int itemssperpage);

        AdminQueryServiceModel PublicStoriesUser(
             string searchterm,
               int currentpage,
              int itemssperpage,string userid);



        AdminStoryServiceModel DetailsStory(int id);

        AdminStoryServiceModel DetailsStoryUser(int id);

        bool DeleteStory(int id);

        bool EditStory(
           int id,
           string title,
           int genreId,
           string topic,
           string imageurl,
           string pseudonym,
           string description
           );




      
    }
}
