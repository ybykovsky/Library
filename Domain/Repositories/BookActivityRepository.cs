using Library.Domain.Entities;
using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public class BookActivityRepository : BaseRepository<BookActivity>, IBookActivityRepository
    {
        public BookActivityRepository()
            : base()
        { 
        }

        public BookActivityRepository(DataBaseContext context)
            : base(context)
        {
        }
    }
}
