using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataClasses.Input
{

    [XmlRoot(ElementName = "Generation")]
    public class Generation
    {

        [XmlElement(ElementName = "Day")]
        public List<Day> Day { get; set; }
    }
}
