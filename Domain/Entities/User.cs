﻿using Library.Domain.Enums;
using Library.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class User : IdentityUser, IEntity
    {
        public virtual ICollection<UserBook> UserBooks { get; set; }
        public virtual ICollection<BookActivity> BookActivities { get; set; }

        public User()
            : base()
        {
            UserBooks = new List<UserBook>();
            BookActivities = new List<BookActivity>();
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
 }
