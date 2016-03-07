using Library.Domain.Enums;
using Library.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class BookActivity : BaseEntity
    {
        public string Notes { get; set; }

        public BookingStatus Status { get; set; }
        public DateTime Date { get; set; }

        public string BookId { get; set; }
        public Book Book { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
