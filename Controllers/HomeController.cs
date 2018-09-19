using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFBooksAndAuthors.Models;
using Microsoft.EntityFrameworkCore;

namespace EFBooksAndAuthors.Controllers
{
    public class HomeController : Controller
    {
        public Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.AllAuthors = GetAuthors();
            viewModel.AllBooks = GetBooks();
            viewModel.AllPublishers = GetPublishers();

            // List<Author> AllAuthors = _context.Authors.ToList();
            // Console.WriteLine("====================================================================");
            // Console.WriteLine(AllAuthors.Count);

            // foreach(Author author in AllAuthors)
            // {
            //     Console.WriteLine(author.First_Name + " " + author.Last_Name);
            // }

            // ViewBag.AllAuthors = AllAuthors;

            return View(viewModel);
        }

        [HttpPost("AddAuthor")]
        public IActionResult Add(Author author)
        {
            if(ModelState.IsValid)
            {
                // Add Author
                _context.Authors.Add(author);
                _context.SaveChanges();

                return RedirectToAction("Index");
            } else {
                // display errors
                // List<Author> AllAuthors = _context.Authors.ToList();
                // ViewBag.AllAuthors = AllAuthors;

                IndexViewModel viewModel = new IndexViewModel();
                viewModel.AllAuthors = GetAuthors();
                viewModel.AllBooks = GetBooks();
                viewModel.AllPublishers = GetPublishers();
                viewModel.Author = author;

                return View("Index", viewModel);
            }
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(Book book)
        {
            IndexViewModel ViweToIndex = new IndexViewModel();
            ViweToIndex.AllAuthors = GetAuthors();

            if(ModelState.IsValid)
            {
                // add the book
                book.Author = _context.Authors.Where(author => author.AuthorId == book.AuthorId).FirstOrDefault();
                _context.Books.Add(book);
                _context.SaveChanges();

                return RedirectToAction("Index");
            } else {
                // show the validations
                ViweToIndex.Book = book;
                ViweToIndex.AllBooks = GetBooks();
                ViweToIndex.AllPublishers = GetPublishers();

                return View("Index", ViweToIndex);
            }
        }

        [HttpPost("AddPublisher")]
        public IActionResult AddPublisher(Publisher publisher)
        {
            if(ModelState.IsValid)
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                IndexViewModel ViweToIndex = new IndexViewModel();
                ViweToIndex.Publisher = publisher;
                ViweToIndex.AllAuthors = GetAuthors();
                ViweToIndex.AllBooks = GetBooks();
                ViweToIndex.AllPublishers = GetPublishers();

                return View("Index", ViweToIndex);
            }
        }

        [HttpPost("AddBookToPublisher")]
        public IActionResult AddBookToPublisher(Publication publication)
        {
            if(ModelState.IsValid)
            {
                Book book = _context.Books.SingleOrDefault(b => b.BookId == publication.BookId);
                Publisher publisher = _context.Publishers.SingleOrDefault(p => p.PublisherId == publication.PublisherId);

                publication.Book = book;
                publication.Publisher = publisher;

                _context.Publications.Add(publication);
                _context.SaveChanges();

                return RedirectToAction("Index");
            } else {
                IndexViewModel ViweToIndex = new IndexViewModel();
                ViweToIndex.Publication = publication;
                ViweToIndex.AllAuthors = GetAuthors();
                ViweToIndex.AllBooks = GetBooks();
                ViweToIndex.AllPublishers = GetPublishers();

                return View("Index", ViweToIndex);
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Author> GetAuthors()
        {
            return _context.Authors
            .Include(author => author.Books)
            .ThenInclude(book => book.Publishers)
            .ThenInclude(publication => publication.Publisher)
            .ToList();
        }
        private List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        private List<Publisher> GetPublishers()
        {
            return _context.Publishers.ToList();
        }
    }
}
