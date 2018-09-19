using System;
using System.ComponentModel.DataAnnotations;

namespace EFBooksAndAuthors.Models
{
    public class Publication
    {
        [Key]
        public long PublicationId { get; set; }

        public long BookId { get; set; }
        public Book Book { get; set; }
 
        public long PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public DateTime PublishedDate {get; set;}

        public Publication()
        {
            PublishedDate = DateTime.Now;
        }
    }
}