using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.Serialization;
using SPA.DAL.Objects;
using SPA_Task.DAL;
using SPA_Task.Utils;
using SPA_Task.DAL.Objects;

namespace SPA.Controllers
{    
    public class MatchesController : BaseController
    {
        // GET api/matches
        public IEnumerable<EventAndMatches> GetAllMatches()
        {
            return GetDataFromDB.GetMatchesFromDb();
        }
    }
}
