using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Library.Domain.Entities;

namespace Library.Domain
{
    public class DataBaseContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public Guid T { get; set; }

        public DataBaseContext()
            : base("DbConnection")
        {
            T = Guid.NewGuid();
            Database.SetInitializer<DataBaseContext>(new ContextInitializer());
        }

        public static DataBaseContext Create()
        {
            return new DataBaseContext();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookActivity> BookActivities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Role>()
                .ToTable("Roles")
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
        }
    }
}
