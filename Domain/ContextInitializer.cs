﻿using Library.Domain.Entities;
using Library.Domain.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Library.Domain
{
    public class ContextInitializer : /*CreateDatabaseIfNotExists<DataBaseContext>*/ DropCreateDatabaseAlways<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            InitializeDefaultUserAndRoles(context);
            InitializeDefaultAuthorsAndBooks(context);
        }


        private void InitializeDefaultUserAndRoles(DataBaseContext context)
        {
            var userManager = new UserManager<User, Guid>(new UserStore(context));
            var roleManager = new RoleManager<Role, Guid>(new RoleStore(context));

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            string userRole = "User";
            string adminRole = "Admin";

            if (!roleManager.RoleExists(adminRole))
            {
                roleManager.Create(new Role(adminRole));
            }

            if (!roleManager.RoleExists(userRole))
            {
                roleManager.Create(new Role(userRole));
            }

            User adminUser = new User
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                FirstName = "Admin",
                LastName = "Admin"
            };

            var adminUserResult = userManager.Create(adminUser, "123456");
            if (adminUserResult.Succeeded)
            {
                userManager.AddToRole(adminUser.Id, adminRole);
            }


            User userUser = new User
            {
                UserName = "user@user.com",
                Email = "user@user.com",
                FirstName = "User",
                LastName = "User"
            };

            var userUserResult = userManager.Create(userUser, "123456");
            if (userUserResult.Succeeded)
            {
                userManager.AddToRole(userUser.Id, userRole);
            }
        }

        private void InitializeDefaultAuthorsAndBooks(DataBaseContext context)
        {
            Genre detectiveGenre = new Genre
            {
                Name = "Detective"
            };

            context.Genres.Add(detectiveGenre);

            Author authorBob = new Author
            {
                FirstName = "Bob",
                LastName = "Jobson",
                Books = new List<Book>()
                {
                    new Book { Title = "How to earn cash", Count = 2, Genres = new List<Genre> { detectiveGenre } },
                    new Book { Title = "Boring book", Count = 1, Genres = new List<Genre> { detectiveGenre } }
                }
            };

            context.Authors.Add(authorBob);

            context.SaveChanges();
        }
    }
}
