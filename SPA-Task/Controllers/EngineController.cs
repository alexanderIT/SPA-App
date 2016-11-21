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

namespace SPA.Controllers
{    
    public class EngineController : BaseController
    {
        // GET api/engine
        public IEnumerable<Match> GetAllMatches()
        {
            return new GetDataFromDB(new UowData()).GetMatchesFromDb();
        }
    }
}
