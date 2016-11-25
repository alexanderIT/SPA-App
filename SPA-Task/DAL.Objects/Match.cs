using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SPA.DAL.Objects
{
    [XmlRoot(ElementName = "Match")]
    public class Match
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        public int ID { get; set; }

        [XmlAttribute(AttributeName = "StartDate")]
        public string StartDate { get; set; }

        [XmlAttribute(AttributeName = "MatchType")]
        public string MatchType { get; set; }

        [XmlElement(ElementName = "Bet")]
        public List<Bet> Bets { get; set; }

        public int EventID { get; set; }
    }
}
