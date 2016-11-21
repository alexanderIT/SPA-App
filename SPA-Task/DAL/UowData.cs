using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPA.DAL;
using SPA.DAL.Objects;
using SPA_Task.Models;

namespace SPA_Task.DAL
{
    public class UowData : IUowData
    {
        private readonly SPADBContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UowData()
            : this(new SPADBContext())
        {
        }

        public UowData(SPADBContext context)
        {
            this.context = context;
        }

        public bool IsDbReady()
        {
            return context.Database.Exists();
        }

        public IRepository<XmlSports> XmlSports
        {
            get
            {
                return this.GetRepository<XmlSports>();
            }
        }

        public IRepository<Odd> Odds
        {
            get
            {
                return this.GetRepository<Odd>();
            }
        }

        public IRepository<Event> Events
        {
            get
            {
                return this.GetRepository<Event>();
            }
        }

        public IRepository<Match> Matches
        {
            get
            {
                return this.GetRepository<Match>();
            }
        }

        public IRepository<Bet> Bets
        {
            get
            {
                return this.GetRepository<Bet>();
            }
        }

        public IRepository<Sport> Sport
        {
            get
            {
                return this.GetRepository<Sport>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}