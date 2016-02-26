using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        public int Count { get; set; }

        public Guid AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public virtual ICollection<UserBook> UserBooks { get; set; }
        public virtual ICollection<BookActivity> BookActivities { get; set; }

        public Book()
        {
            UserBooks = new List<UserBook>();
            BookActivities = new List<BookActivity>();
        }
    }
}
