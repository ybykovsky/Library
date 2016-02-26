using System.Linq;

namespace Library.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> All { get; }
    }
}
