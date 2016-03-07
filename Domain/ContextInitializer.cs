using Library.Domain.Entities;
using Library.Domain.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Library.Domain
{
    public class ContextInitializer : DropCreateDatabaseAlways<DataBaseContext> //CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            InitializeDefaultUserAndRoles(context);
            InitializeDefaultAuthorsAndBooks(context);
        }


        private void InitializeDefaultUserAndRoles(DataBaseContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

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
                roleManager.Create(new IdentityRole(adminRole));
            }

            if (!roleManager.RoleExists(userRole))
            {
                roleManager.Create(new IdentityRole(userRole));
            }

            User adminUser = new User
            {
                UserName = "Admin",
                Email = "admin@admin.com"
            };

            var adminUserResult = userManager.Create(adminUser, "admin");
            if (adminUserResult.Succeeded)
            {
                userManager.AddToRole(adminUser.Id, adminRole);
            }


            User userUser = new User
            {
                UserName = "User",
                Email = "user@user.com"
            };

            var userUserResult = userManager.Create(userUser, "user");
            if (userUserResult.Succeeded)
            {
                userManager.AddToRole(userUser.Id, userRole);
            }
        }

        private void InitializeDefaultAuthorsAndBooks(DataBaseContext context)
        {
            Author authorBob = new Author
            {
                FirstName = "Bob",
                LastName = "Gop",
                Books = new List<Book>()
                {
                    new Book { Title = "Interstellar", Count = 2 },
                    new Book { Title = "Boring book", Count = 1 }
                }
            };

            context.Authors.Add(authorBob);

            context.SaveChanges();
        }
    }
}
