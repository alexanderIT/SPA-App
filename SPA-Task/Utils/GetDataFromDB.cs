using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading;
using System.Web;
using SPA.DAL.Objects;
using SPA_Task.DAL;
using SPA_Task.DAL.Objects;

namespace SPA_Task.Utils
{
    public static class GetDataFromDB 
    {
        public static IUowData Data { get; set; }

        static GetDataFromDB()
        {
            Data = new UowData();
        }
        public static IEnumerable<EventAndMatches> GetMatchesFromDb()
        {
            List<EventAndMatches> result = new List<EventAndMatches>();
            if (!Data.IsDbReady())
            {
                return Enumerable.Empty<EventAndMatches>();
            }
            var matches = Data.Matches.All()
               .Where(x => x.Bets.Any(y => y.Odds.Count != 0)
                   && DbFunctions.CreateDateTime(SqlFunctions.DatePart("yy", x.StartDate),
                       SqlFunctions.DatePart("mm", x.StartDate),
                       SqlFunctions.DatePart("dd", x.StartDate),
                       SqlFunctions.DatePart("hh", x.StartDate),
                       SqlFunctions.DatePart("mi", x.StartDate),
                       SqlFunctions.DatePart("ss", x.StartDate)) <= DbFunctions.AddHours(DateTime.Now, 24))
                       .GroupBy(x => x.EventID)
                       .ToDictionary(group => group.Key,group => group.ToList());

            foreach (var item in matches)
            {
                foreach (var match in item.Value)
                {
                    result.Add(new EventAndMatches()
                    {
                        Event = Data.Events.All().FirstOrDefault(y => y.ID == item.Key).Name,
                        Match = match
                    });
                }
            }

            return result;      
                                            
        }
    }
}