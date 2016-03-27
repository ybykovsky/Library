using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Domain.Interfaces;
using Library.Web.Infrastructure.Interfaces;
using Library.Domain.Entities;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISiteConfig _siteConfig;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;

        public HomeController(ISiteConfig siteConfig, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _siteConfig = siteConfig;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public ActionResult Index()
        {
            Book book =_bookRepository.GetAll().FirstOrDefault();

            if (book != null)
            {
                ViewBag.bookName = book.Title;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}