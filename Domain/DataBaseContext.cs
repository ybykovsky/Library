using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Library.Domain.Entities;

namespace Library.Domain
{
    public class DataBaseContext : IdentityDbContext<User>
    {
        public DataBaseContext()
            : base("DbConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<DataBaseContext>(new ContextInitializer());
        }

        public static DataBaseContext Create()
        {
            return new DataBaseContext();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookActivity> BookActivities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("Users");
                //.Property(p => p.Id)
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
