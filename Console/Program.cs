using Library.Domain.Entities;
using Library.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Library.Domain;
using Library.Domain.Enums;

namespace Library.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

                    //UserRepository userRepository = new UserRepository(context);
                    //BookRepository bookRepository = new BookRepository(context);

                    //foreach (User user in userRepository.All.AsNoTracking())
                    //{
                    //    Console.WriteLine(user.UserName);
                    //}

                    //Book book = bookRepository.All.First();
                    //User user1 = userRepository.All.First();

                    //user1.UserBooks.Add(new UserBook
                    //{
                    //    Book = book,
                    //    Date = DateTime.UtcNow,
                    //    Status = BookingStatus.Reserved
                    //});

                    BookRepository bookRepository = new BookRepository(context);
                    AuthorRepository authorRepository = new AuthorRepository(context);

                    //Console.WriteLine(bookRepository.All.First().Title);

                    Author author = authorRepository.GetAll().First();
                    var query = bookRepository.FindAllByAuthor(author.Id);
                    var a = query.ToList();
                    var b = query.ToList();

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
