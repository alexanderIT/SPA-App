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
        private const string Url = "http://vitalbet.net/sportxml";
        private static WebClient _client;
        public static IUowData Data { get; set; }

        public InsertDataIntoDb()
        {
            Data = new UowData();
            _client = new WebClient();
        }

        public void GetFromServiceAndInsertToDb()
        {
            using (_client)
            {
                string result = _client.DownloadString(Url);
                XmlSerializer serializer = new XmlSerializer(typeof (XmlSports));
                using (var stringReader = new StringReader(result))
                {
                    XmlSports xmlSports = (XmlSports) serializer.Deserialize(stringReader);
                    var model = xmlSports.Sports.Where(x => x.Events.Count() < 14).FirstOrDefault();
                    Data.Sport.Add(model);
                    Data.SaveChanges();
                }                
            }            
        }
    }
}