using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Match = SPA.DAL.Objects.Match;

namespace SPA.DAL.Objects
{
    [XmlRoot(ElementName = "Event")]
    public class Event
    {
        [XmlElement(ElementName = "Match")]
        public List<Match> Matches { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        public int ID { get; set; }

        [XmlAttribute(AttributeName = "IsLive")]
        public string IsLive { get; set; }

        [XmlAttribute(AttributeName = "CategoryID")]
        public string CategoryID { get; set; }
    }
}
