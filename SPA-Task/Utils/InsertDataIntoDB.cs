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
using SPA_Task.DAL;
using SPA_Task.Utils;

namespace SPA.Utils
{
    public class InsertDataIntoDb
    {
        private static Timer _timer;
        private const string Url = "http://vitalbet.net/sportxml";
        private static WebClient _client;
        protected IUowData Data { get; set; }

        public InsertDataIntoDb(IUowData data)
        {
            Data = data;
            _client = new WebClient();
        }

        public void StartGetFromServiceCycle()
        {
            _timer = new Timer(_ => GetFromServiceAndInsertToDb(), null, 0, 1000 * 60); //every 60 seconds
        }

        private void GetFromServiceAndInsertToDb()
        {
            using (_client)
            {
                string result = _client.DownloadString(Url);
                XmlSerializer serializer = new XmlSerializer(typeof (XmlSports));
                using (var stringReader = new StringReader(result))
                {
                    XmlSports xmlSports = (XmlSports) serializer.Deserialize(stringReader);
                    Data.XmlSports.Add(xmlSports);
                    Data.XmlSports.SaveChanges();
                }
            }
        }
    }
}