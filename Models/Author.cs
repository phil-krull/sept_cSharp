using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFBooksAndAuthors.Models
{
    public class Author
    {
        [Key]
        public long AuthorId {get; set;}

        [Required]
        public string First_Name {get; set;}
        
        [Required]
        public string Last_Name {get; set;}

        public List<Book> Books {get; set;}
        public DateTime Created_At {get; set;}

        public DateTime Updated_At {get; set;}

        public Author()
        {
            Books = new List<Book>();
            Created_At = DateTime.Now;
            Updated_At = DateTime.Now;
        }
    }
}