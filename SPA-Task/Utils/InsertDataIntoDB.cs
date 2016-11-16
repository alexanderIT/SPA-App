using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Xml.Serialization;
using SPA.DAL;
using SPA.DAL.Objects;
using SPA.Manger;

namespace SPA.Utils
{
    public static class InsertDataIntoDb
    {
        private static Timer _timer;
        private const string Url = "http://vitalbet.net/sportxml";
        private static WebClient _client;

        static InsertDataIntoDb()
        {
            _client = new WebClient();
        }

        public static void StartGetFromServiceCycle()
        {
            _timer = new Timer(_ => GetFromServiceAndInsertToDb(), null, 0, 1000 * 60); //every 60 seconds
        }

        private static void GetFromServiceAndInsertToDb()
        {
            using (_client)
            {
                string result = _client.DownloadString(Url);
                XmlSerializer serializer = new XmlSerializer(typeof(XmlSports));
                using (var stringReader = new StringReader(result))
                {
                    XmlSports xmlSports = (XmlSports)serializer.Deserialize(stringReader);
                    Manager.XmlSports.Add(xmlSports);
                    Manager.XmlSports.SaveChanges();
                }
            }
        }
    }
}