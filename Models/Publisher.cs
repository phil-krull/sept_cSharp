using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFBooksAndAuthors.Models
{
    public class Publisher
    {
        [Key]
        public long PublisherId {get; set;}

        [Required]
        public string Name {get; set;}

        public List<Publication> Books {get; set;}
        
        public DateTime Created_At {get; set;}

        public DateTime Updated_At {get; set;}

        public Publisher()
        {
            Books = new List<Publication>();
            Created_At = DateTime.Now;
            Updated_At = DateTime.Now;
        }
    }
}