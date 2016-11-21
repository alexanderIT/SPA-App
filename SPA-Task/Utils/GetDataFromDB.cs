using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading;
using System.Web;
using SPA.DAL.Objects;
using SPA_Task.DAL;

namespace SPA_Task.Utils
{
    public class GetDataFromDB 
    {
        protected IUowData Data { get; set; }

        public GetDataFromDB(IUowData data)
        {
            Data = data;
        }
        public IEnumerable<Match> GetMatchesFromDb()
        {
            if (!Data.IsDbReady())
            {
                return Enumerable.Empty<Match>();
            }
            var matches = Data.Matches.All()
               .Where(x => x.Bets.Any(y => y.Odds.Count != 0)
                   && DbFunctions.CreateDateTime(SqlFunctions.DatePart("yy", x.StartDate),
                       SqlFunctions.DatePart("mm", x.StartDate),
                       SqlFunctions.DatePart("dd", x.StartDate),
                       SqlFunctions.DatePart("hh", x.StartDate),
                       SqlFunctions.DatePart("mi", x.StartDate),
                       SqlFunctions.DatePart("ss", x.StartDate)) <= DbFunctions.AddHours(DateTime.Now, 24))
               .ToList();

                return matches;                     
        }       
    }
}