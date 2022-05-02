﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PowerGeneratorStats.DataClasses
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

    [XmlRoot(ElementName = "Generation")]
    public class Generation
    {

        [XmlElement(ElementName = "Day")]
        public List<Day> Day { get; set; }
    }

    [XmlRoot(ElementName = "WindGenerator")]
    public class WindGenerator
    {

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Generation")]
        public Generation Generation { get; set; }

        [XmlElement(ElementName = "Location")]
        public string Location { get; set; }
    }

    [XmlRoot(ElementName = "Wind")]
    public class Wind
    {

        [XmlElement(ElementName = "WindGenerator")]
        public List<WindGenerator> WindGenerator { get; set; }
    }

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

    [XmlRoot(ElementName = "Gas")]
    public class Gas
    {

        [XmlElement(ElementName = "GasGenerator")]
        public GasGenerator GasGenerator { get; set; }
    }

    [XmlRoot(ElementName = "CoalGenerator")]
    public class CoalGenerator
    {

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Generation")]
        public Generation Generation { get; set; }

        [XmlElement(ElementName = "TotalHeatInput")]
        public double TotalHeatInput { get; set; }

        [XmlElement(ElementName = "ActualNetGeneration")]
        public double ActualNetGeneration { get; set; }

        [XmlElement(ElementName = "EmissionsRating")]
        public double EmissionsRating { get; set; }
    }

    [XmlRoot(ElementName = "Coal")]
    public class Coal
    {

        [XmlElement(ElementName = "CoalGenerator")]
        public CoalGenerator CoalGenerator { get; set; }
    }

    [XmlRoot(ElementName = "GenerationReport")]
    public class GenerationReport
    {

        [XmlElement(ElementName = "Wind")]
        public Wind Wind { get; set; }

        [XmlElement(ElementName = "Gas")]
        public Gas Gas { get; set; }

        [XmlElement(ElementName = "Coal")]
        public Coal Coal { get; set; }
    }



    ////[XmlRoot(ElementName = "GenerationReport")]
    //public class GenerationReport
    //{
    //    //[XmlElement(ElementName = "Wind")]
    //    public Wind Wind { get; set; }
    //    //[XmlElement(ElementName = "Gas")]
    //    public Gas Gas { get; set; }
    //    //[XmlElement(ElementName = "Coal")]
    //    public Coal Coal { get; set; }
    //}

    ////[XmlRoot(ElementName = "Day")]
    //public class Day
    //{
    //    //[XmlElement(ElementName = "Date")]
    //    public string Date { get; set; }
    //    //[XmlElement(ElementName = "Energy")]
    //    public string Energy { get; set; }
    //    //[XmlElement(ElementName = "Price")]
    //    public string Price { get; set; }
    //}

    ////[XmlRoot(ElementName = "Generation")]
    //public class Generation
    //{
    //    //[XmlElement(ElementName = "Day")]
    //    public List<Day> Day { get; set; }
    //}

    ////[XmlRoot(ElementName = "WindGenerator")]
    //public class WindGenerator
    //{
    //    //[XmlElement(ElementName = "Name")]
    //    public string Name { get; set; }
    //    //[XmlElement(ElementName = "Generation")]
    //    public Generation Generation { get; set; }
    //    //[XmlElement(ElementName = "Location")]
    //    public string Location { get; set; }
    //}

    ////[XmlRoot(ElementName = "Wind")]
    //public class Wind
    //{
    //    //[XmlElement(ElementName = "WindGenerator")]
    //    public List<WindGenerator> WindGenerator { get; set; }
    //}

    ////[XmlRoot(ElementName = "GasGenerator")]
    //public class GasGenerator
    //{
    //    //[XmlElement(ElementName = "Name")]
    //    public string Name { get; set; }
    //    //[XmlElement(ElementName = "Generation")]
    //    public Generation Generation { get; set; }
    //    //[XmlElement(ElementName = "EmissionsRating")]
    //    public string EmissionsRating { get; set; }
    //}

    ////[XmlRoot(ElementName = "Gas")]
    //public class Gas
    //{
    //    //[XmlElement(ElementName = "GasGenerator")]
    //    public GasGenerator GasGenerator { get; set; }
    //}

    ////[XmlRoot(ElementName = "CoalGenerator")]
    //public class CoalGenerator
    //{
    //    //[XmlElement(ElementName = "Name")]
    //    public string Name { get; set; }
    //    //[XmlElement(ElementName = "Generation")]
    //    public Generation Generation { get; set; }
    //    //[XmlElement(ElementName = "TotalHeatInput")]
    //    public string TotalHeatInput { get; set; }
    //    //[XmlElement(ElementName = "ActualNetGeneration")]
    //    public string ActualNetGeneration { get; set; }
    //    //[XmlElement(ElementName = "EmissionsRating")]
    //    public string EmissionsRating { get; set; }
    //}

    ////[XmlRoot(ElementName = "Coal")]
    //public class Coal
    //{
    //    //[XmlElement(ElementName = "CoalGenerator")]
    //    public CoalGenerator CoalGenerator { get; set; }
    //}

}
