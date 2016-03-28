using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.Domain.Interfaces;

namespace Library.Web.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Reserve(Guid userId, Guid bookId)
        { 

        }
    }
}
