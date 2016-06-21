using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Domain.Interfaces;
using Library.Web.Infrastructure.Interfaces;
using Library.Domain.Entities;
using Library.Core.Interfaces;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISiteConfig _siteConfig;
        private IAuthorRepository _authorRepository;

        private IBookManager _bookManager;

        public HomeController(ISiteConfig siteConfig, IBookManager bookManager, IAuthorRepository authorRepository)
        {
            _siteConfig = siteConfig;
            _authorRepository = authorRepository;
            _bookManager = bookManager;
        }

        public ActionResult Index()
        {
            //Book book = _bookManager.GetAllBooks().FirstOrDefault();

            //if (book != null)
            //{
            //    ViewBag.bookName = book.Title;
            //}

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

        public ActionResult Books()
        {
            ViewBag.Message = "Books section.";

            return View();
        }
    }
}