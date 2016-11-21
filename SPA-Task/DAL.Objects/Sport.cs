using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SPA.DAL.Objects
{
    [XmlRoot(ElementName = "Sport")]
    public class Sport
    {
        [XmlElement(ElementName = "Event")]
        public List<Event> Events { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        
        public int ID { get; set; }
    }
}
