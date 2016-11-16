using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SPA.DAL;
using SPA.DAL.Objects;

namespace SPA.Manger
{
    public static class Manager
    {
        private static readonly DbContext _context;
        public static IRepository<XmlSports> XmlSports;
        public static IRepository<Odd> Odds;
        public static IRepository<Event> Events;
        public static IRepository<Match> Matches;
        public static IRepository<Bet> Bets;
        public static IRepository<Sport> Sport;

        public static bool IsDbReady => _context.Database.Exists();

        static Manager()
        {
            _context = new SPADBContext();
            XmlSports = new GenericRepository<XmlSports>(_context);
            Odds = new GenericRepository<Odd>(_context);
            Events = new GenericRepository<Event>(_context);
            Matches = new GenericRepository<Match>(_context);
            Bets = new GenericRepository<Bet>(_context);
            Sport = new GenericRepository<Sport>(_context);
        }
    }
}