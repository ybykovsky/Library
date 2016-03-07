using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Domain.Interfaces;

namespace Library.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        //public BaseEntity()
        //{
        //    Id = Guid.NewGuid().ToString();
        //}
    }
}
