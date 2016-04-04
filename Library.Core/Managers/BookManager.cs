using Library.Core.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Managers
{
    public class BookManager : IBookManager
    {
        protected IBookRepository _bookRepository;
        protected IBookActivityRepository _bookActivityRepository;


        public BookManager(IBookRepository bookRepository, IBookActivityRepository bookActivityRepository)
        {
            _bookRepository = bookRepository;
            _bookActivityRepository = bookActivityRepository;
        }

        public IQueryable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public IQueryable<BookActivity> GetUserActivities(Guid userId)
        {
            return _bookActivityRepository.GetAll().Where(p => p.UserId == userId);
        }

        public IQueryable<BookActivity> GetBookActivities(Guid bookId)
        {
            return _bookActivityRepository.GetAll().Where(p => p.BookId == bookId);
        }

        public void Reserve(Guid userId, Guid bookId)
        {
            // Check for availability

            _bookActivityRepository.Insert(new BookActivity
            {
                UserId = userId,
                BookId = bookId,
                Date = DateTime.UtcNow,
                Status = BookingStatus.Reserved
            });
        }

        public void GetBookOnHands(Guid userId, Guid bookId)
        {
            BookActivity activity = _bookActivityRepository.GetAll().FirstOrDefault();
            if (activity != null && activity.Status == BookingStatus.Reserved)
            {
                activity.Status = BookingStatus.OnHands;
                _bookActivityRepository.Save();
            }

            throw new Exception("GetBookOnHands");
        }

        public void CancelReservation(Guid userId, Guid bookId)
        { 
            BookActivity activity = _bookActivityRepository.GetAll().FirstOrDefault();
            if (activity != null && activity.Status == BookingStatus.Reserved)
            {
                activity.Status = BookingStatus.Cancelled;
                _bookActivityRepository.Save();
            }

            throw new Exception("CancelReservation");
        }

        public void ReturnBook(Guid userId, Guid bookId)
        { 

        }
    }
}
