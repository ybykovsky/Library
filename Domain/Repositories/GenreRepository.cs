using Library.Domain.Entities;
using Library.Domain.Interfaces;
using System.Linq;

namespace Library.Domain.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository()
            : base()
        { 
        }

        public GenreRepository(DataBaseContext context)
            : base(context)
        { 
        }

        public IQueryable<Genre> All
        {
            get { return context.Genres; }
        }
    }
}
