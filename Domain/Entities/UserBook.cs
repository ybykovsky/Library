using Library.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class UserBook
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        public User User { get; set; }

        [Key, Column(Order = 1)]
        public string BookId { get; set; }
        public Book Book { get; set; }

        public BookingStatus Status { get; set; }
        public DateTime Date { get; set; }
    }
}
