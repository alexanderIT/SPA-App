﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SPA.DAL.Objects
{
    public class SPADBContext : DbContext
    {

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
            return base.Set<T>();
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<SPADBContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}