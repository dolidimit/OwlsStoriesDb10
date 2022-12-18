namespace secondapp.Services.Books
{
    public interface IBookService
    {
        BooksQueryServiceModel All(
            string serachterm,
            int currentpage,
            int booksperpage
            );

        BooksQueryServiceModel PublicBooks(
            string serachterm,
            int currentpage,
            int booksperpage
            );

        BooksQueryServiceModel AllBooks(  
            int currentpage,
            int booksperpage
            );

       

        BooksQueryServiceModel AllBooksHome(
            int booksperpage
            );

        BooksServiceModel Details(int id);

        int Create(
            string title,
            string rtitle,
            string topic,
            string imageurl,
            string author,
            int pages,
            string description,
            string bookl,
            string bookpdf
            );

        bool Delete(int id);

        bool Edit(
           int id,
           string title,
           string rtitle,
           string topic,
           string imageurl,
           string author,
           int pages,
           string description,
           string booklink,
           string bookpdf
           );




    }
}
