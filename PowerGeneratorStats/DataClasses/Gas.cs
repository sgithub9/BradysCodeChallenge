using System.Xml.Serialization;
using System.Collections.Generic;

namespace DataClasses.Input
{

    [XmlRoot(ElementName = "Gas")]
    public class Gas
    {

        [XmlElement(ElementName = "GasGenerator")]
        public List<GasGenerator> GasGenerator { get; set; }
    }
}
