using SPA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SPA_Task.Utils
{

    public static class FillDataBase
    {
        private static Timer _timer;
        public static void Run()
        {
            _timer = new Timer(_ => new InsertDataIntoDb().GetFromServiceAndInsertToDb(), null, 0, 1000 * 60);
        }
    }
}