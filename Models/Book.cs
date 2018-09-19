using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFBooksAndAuthors.Models
{
    public class Book
    {
        [Key]
        public long BookId {get; set;}

        [Required]
        public string Title {get; set;}

        public long AuthorId {get; set;}
        public Author Author {get; set;}

        public List<Publication> Publishers {get; set;}
        public DateTime Created_At {get; set;}
        public DateTime Updated_At {get; set;}

        public Book()
        {
            Publishers = new List<Publication>();
            Created_At = DateTime.Now;
            Updated_At = DateTime.Now;
        }
    }
}