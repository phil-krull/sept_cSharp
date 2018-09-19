using System.Collections.Generic;

namespace EFBooksAndAuthors.Models
{
    public class IndexViewModel
    {
        // for the forms to add
        public Author Author;
        public Book Book;
        public Publisher Publisher;
        public Publication Publication;

        // display the db info
        public List<Author> AllAuthors = new List<Author>();
        public List<Book> AllBooks = new List<Book>();
        public List<Publisher> AllPublishers = new List<Publisher>();
    }
}