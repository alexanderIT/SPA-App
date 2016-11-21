using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPA.DAL;
using SPA.DAL.Objects;

namespace SPA_Task.DAL
{
    public interface IUowData : IDisposable
    {
        IRepository<XmlSports> XmlSports { get; }

        IRepository<Odd> Odds { get; }

        IRepository<Event> Events { get; }

        IRepository<Match> Matches { get; }

        IRepository<Bet> Bets { get; }

        IRepository<Sport> Sport { get; }

        bool IsDbReady();

        int SaveChanges();
    }
}