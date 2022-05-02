using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataClasses.Input
{

    [XmlRoot(ElementName = "Coal")]
    public class Coal
    {

        [XmlElement(ElementName = "CoalGenerator")]
        public List<CoalGenerator> CoalGenerator { get; set; }
    }
}
