using System.Xml.Serialization;

namespace DataClasses.Input
{

    [XmlRoot(ElementName = "GasGenerator")]
    public class GasGenerator
    {

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Generation")]
        public Generation Generation { get; set; }

        [XmlElement(ElementName = "EmissionsRating")]
        public double EmissionsRating { get; set; }
    }
}
