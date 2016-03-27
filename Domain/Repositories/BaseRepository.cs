using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using System.Linq;

namespace Library.Domain.Repositories
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        protected DataBaseContext context;
        protected DbSet<TEntity> dbSet;

        public BaseRepository()
        {
            this.context = new DataBaseContext();
            this.dbSet = this.context.Set<TEntity>();
        }

        public BaseRepository(DataBaseContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void InsertOrUpdate(TEntity entity)
        {
            dbSet.AddOrUpdate<TEntity>(p => p.Id, entity);
        }

        public virtual void Save()
        {
            this.context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseRepository()
        {
            Dispose(false);
        }
    }
}
