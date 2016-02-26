using Library.Domain.Enums;
using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class User : BaseEntity
    {
        public UserRole Role { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<UserBook> UserBooks { get; set; }
        public virtual ICollection<BookActivity> BookActivities { get; set; }

        public User()
        {
            UserBooks = new List<UserBook>();
            BookActivities = new List<BookActivity>();
        }
    }
}
