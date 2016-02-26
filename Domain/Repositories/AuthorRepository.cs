using Library.Domain.Entities;
using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository()
            : base()
        { 
        }

        public AuthorRepository(DataBaseContext context)
            : base(context)
        { 
        }

        public IQueryable<Author> All
        {
            get { return context.Authors; }
        }
    }
}
