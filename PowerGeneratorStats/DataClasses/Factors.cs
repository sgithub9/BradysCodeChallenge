using System.Xml.Serialization;

namespace DataClasses.Input
{
    [XmlRoot(ElementName = "Factors")]
    public class Factors
    {

        [XmlElement(ElementName = "ValueFactor")]
        public ValueFactor ValueFactor { get; set; }

        [XmlElement(ElementName = "EmissionsFactor")]
        public EmissionsFactor EmissionsFactor { get; set; }
    }
}
