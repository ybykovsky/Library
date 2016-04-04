using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IBookManager
    {
        IQueryable<Book> GetAllBooks();
        IQueryable<BookActivity> GetUserActivities(Guid userId);
        IQueryable<BookActivity> GetBookActivities(Guid bookId);
        void Reserve(Guid userId, Guid bookId);
        void GetBookOnHands(Guid userId, Guid bookId);
        void CancelReservation(Guid userId, Guid bookId);
        void ReturnBook(Guid userId, Guid bookId);
    }
}
