using Library.Domain.Enums;
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
    public class UserRole : IdentityUserRole<Guid> { } 
    public class UserClaim : IdentityUserClaim<Guid> { }
    public class UserLogin : IdentityUserLogin<Guid> { }

    public class Role : IdentityRole<Guid, UserRole>, IEntity
    { 
        public Role() { } 
        public Role(string name) { Name = name; } 
    } 


    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>, IEntity
    {
        public virtual ICollection<UserBook> UserBooks { get; set; }
        public virtual ICollection<BookActivity> BookActivities { get; set; }

        public User()
            : base()
        {
            UserBooks = new List<UserBook>();
            BookActivities = new List<BookActivity>();
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, Guid> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class UserStore : UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim> 
    { 
        public UserStore(DataBaseContext context)
            : base(context) 
        { 
        } 
    } 

    public class RoleStore : RoleStore<Role, Guid, UserRole> 
    { 
        public RoleStore(DataBaseContext context)
            : base(context) 
        { 
        } 
    } 
 }
