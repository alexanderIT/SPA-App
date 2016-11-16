﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace SPA.DAL
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }
        private readonly object _lockObj =new object();

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            lock (_lockObj)
            {
                return this.DbSet.AsQueryable();
            }            
        }

        public virtual T GetById(int id)
        {
            lock (_lockObj)
            {
                return this.DbSet.Find(id);
            }            
        }

        public virtual void Add(T entity)
        {
            lock (_lockObj)
            {
                DbEntityEntry entry = this.Context.Entry(entity);
                if (entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Added;
                }
                else
                {
                    this.DbSet.Add(entity);
                }
            }          
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            lock (_lockObj)
            {
                DbEntityEntry entry = this.Context.Entry(entity);

                entry.State = EntityState.Detached;
            }
           
        }

        public int SaveChanges()
        {
            lock (_lockObj)
            {
                return this.Context.SaveChanges();
            }
            
        }

        public void Dispose()
        {
            lock (_lockObj)
            {
                this.Context.Dispose();
            }            
        }
    }
}