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

        public HomeController(ISiteConfig siteConfig, IBookRepository bookRepository)
        {
            _siteConfig = siteConfig;
            _bookRepository = bookRepository;
        }

        public ActionResult Index()
        {
            Book book =_bookRepository.All.FirstOrDefault();

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