﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GroupUpWeb.Helpers.EF
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public virtual IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> path)
        {
            return DbSet.Include(path);
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> query)
        {
            return DbSet.Where(query);
        }
        public virtual void DisableAutoDetectChanges()
        {
            DbContext.Configuration.AutoDetectChangesEnabled = false;
        }
        public virtual void EnableAutoDetectChanges()
        {
            DbContext.Configuration.AutoDetectChangesEnabled = true;
        }

        public virtual void RunWithoutDetectChanges(Action<object> action)
        {

            try
            {
                DbContext.Configuration.AutoDetectChangesEnabled = false;
                action.Invoke(null);
            }
            finally
            {
                DbContext.Configuration.AutoDetectChangesEnabled = true;
            }

        }

        public virtual int RunSqlCommand(string sql, params object[] parameters)
        {
            return DbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

    }
}