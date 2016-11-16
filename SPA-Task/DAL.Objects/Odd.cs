using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SPA.DAL.Objects
{
    [XmlRoot(ElementName = "Odd")]
    public class Odd
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
       
        public int ID { get; set; }

        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        [XmlAttribute(AttributeName = "SpecialBetValue")]
        public string SpecialBetValue { get; set; }
    }
}
