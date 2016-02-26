using Library.Domain.Entities;
using System.Data.Entity;

namespace Library.Domain
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext()
            : base("DbConnection")
        {
            Database.SetInitializer<DataBaseContext>(new ContextInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookActivity> BookActivities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
