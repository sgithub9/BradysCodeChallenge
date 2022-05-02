using System;
using System.Xml.Serialization;

namespace DataClasses.Input
{
    [XmlRoot(ElementName = "Day")]
    public class Day
    {
        [XmlElement(ElementName = "Date")]
        public DateTime Date { get; set; }

        [XmlElement(ElementName = "Energy")]
        public double Energy { get; set; }

        [XmlElement(ElementName = "Price")]
        public double Price { get; set; }
    }

}
