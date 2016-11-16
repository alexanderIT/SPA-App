using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading;
using System.Web;
using SPA.DAL.Objects;
using SPA.Manger;

namespace SPA_Task.Utils
{
    public static class GetDataFromDB
    {
        public static IEnumerable<Match> GetMatchesFromDb()
        {        
            var matches = Manager.Matches.All()
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