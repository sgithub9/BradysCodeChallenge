using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataClasses.Output
{
    [XmlRoot(ElementName = "Generator")]
    public class Generator
    {

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Total")]
        public double Total { get; set; }
    }

    [XmlRoot(ElementName = "Totals")]
    public class Totals
    {

        [XmlElement(ElementName = "Generator")]
        public List<Generator> Generator { get; set; }
    }

    [XmlRoot(ElementName = "Day")]
    public class Day
    {

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Date")]
        public DateTime Date { get; set; }

        [XmlElement(ElementName = "Emission")]
        public double Emission { get; set; }
    }

    [XmlRoot(ElementName = "MaxEmissionGenerators")]
    public class MaxEmissionGenerators
    {

        [XmlElement(ElementName = "Day")]
        public List<Day> Day { get; set; }
    }

    [XmlRoot(ElementName = "ActualHeatRate")]
    public class ActualHeatRate
    {

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "HeatRate")]
        public double HeatRate { get; set; }
    }

    [XmlRoot(ElementName = "ActualHeatRates")]
    public class ActualHeatRates
    {

        [XmlElement(ElementName = "ActualHeatRate")]
        public List<ActualHeatRate> ActualHeatRate { get; set; }
    }

    [XmlRoot(ElementName = "GenerationOutput")]
    public class GenerationOutput
    {

        [XmlElement(ElementName = "Totals")]
        public Totals Totals { get; set; }

        [XmlElement(ElementName = "MaxEmissionGenerators")]
        public MaxEmissionGenerators MaxEmissionGenerators { get; set; }

        [XmlElement(ElementName = "ActualHeatRates")]
        public ActualHeatRates ActualHeatRates { get; set; }

    }
}
