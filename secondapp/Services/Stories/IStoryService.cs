namespace secondapp.Services.Stories
{
    public interface IStoryService
    {
        StoriesQueryServiceModel AllMine
           (string searchterm,
           int currentpage,
           int storiesper,
           string userId);

        StoriesServiceModel Details(int id);

        bool Delete(int id);

        int Create(
            string title,
            int genreId,
            string topic,
            string imageurl,
            string pseudonym,
            int age,
            string publicm,
            string description,
            string userId
            );

        bool Edit(
            int id,
            string title,
            int genreId,
            string topic,
            string imageurl,
            string pseudonym,
            int age,
            string publicm,
            string description
            );

        bool SendUsersBook(string userId);


    }
}
