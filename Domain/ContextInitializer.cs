using Library.Domain.Entities;
using Library.Domain.Enums;
using System.Collections.Generic;
using System.Data.Entity;

namespace Library.Domain
{
    public class ContextInitializer : CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            User userEric = new User { Name = "Eric", Email = "eric@lib.com", Password = "admin", Role = UserRole.User };
            User userJohn = new User { Name = "John", Email = "john@lib.com", Password = "admin", Role = UserRole.User };
            User userYury = new User { Name = "Yury", Email = "yury@lib.com", Password = "admin", Role = UserRole.Moderator };

            context.Users.Add(userEric);
            context.Users.Add(userJohn);
            context.Users.Add(userYury);

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
