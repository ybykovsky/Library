using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.Domain.Interfaces;
using Library.Web.Infrastructure.Interfaces;
using Library.Domain.Entities;
using Library.Core.Interfaces;

namespace Library.Web.Controllers
{
    public class BookController : ApiController
    {
        private IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        public List<Book> Get()
        {
            return _bookManager.GetAllBooks().ToList();
        }

        //public void Reserve(Guid userId, Guid bookId)
        //{ 

        //}
    }
}
