using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SPA.DAL.Objects
{
    [XmlRoot(ElementName = "XmlSports")]
    public class XmlSports
    {
       
        public int ID { get; set; }

        [XmlElement(ElementName = "Sport")]
        public List<Sport> Sports { get; set; }

        [XmlAttribute(AttributeName = "CreateDate")]
        public string CreateDate { get; set; }
    }
}
