using Library.Domain.Entities;
using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository()
            : base()
        { 
        }

        public BookRepository(DataBaseContext context)
            : base(context)
        { 
        }

        public IQueryable<Book> FindAllByAuthor(Guid authorId)
        {
            return GetAll().Where(p => p.AuthorId == authorId);
        }
    }
}
