using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SPA.DAL.Objects
{
    [XmlRoot(ElementName = "Bet")]
    public class Bet
    {
        [XmlElement(ElementName = "Odd")]
        public List<Odd> Odds { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        public int ID { get; set; }

        [XmlAttribute(AttributeName = "IsLive")]
        public string IsLive { get; set; }
    }
}
