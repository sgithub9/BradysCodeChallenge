using System.Xml.Serialization;

namespace DataClasses.Input
{
    [XmlRoot(ElementName = "ReferenceData")]
    public class ReferenceData
    {

        [XmlElement(ElementName = "Factors")]
        public Factors Factors { get; set; }
    }
}
