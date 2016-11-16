using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SPA.DAL.Objects
{
    public class SPADBContext : DbContext
    {

        private object lockObj = new object();

        public SPADBContext()
            : base("DefaultConnection")
        {
        }
        public virtual DbSet<Odd> Odds { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<XmlSports> XMLSports { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            lock (lockObj)
            {
                return base.Set<T>();
            }            
        }
    }
}