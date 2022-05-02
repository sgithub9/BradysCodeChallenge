using System.Xml.Serialization;

namespace DataClasses.Input
{
    [XmlRoot(ElementName = "EmissionsFactor")]
    public class EmissionsFactor
    {

        [XmlElement(ElementName = "High")]
        public double High { get; set; }

        [XmlElement(ElementName = "Medium")]
        public double Medium { get; set; }

        [XmlElement(ElementName = "Low")]
        public double Low { get; set; }
    }
}
