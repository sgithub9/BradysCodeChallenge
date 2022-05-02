using DataClasses.Input;
using DataClasses.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerGeneratorStats
{
    class ProcessGeneratorStats
    {
        public static void ProcessStats(string inputFilePath, string inputFileName, string outputFilePath, string outputFileName)
        {
            try
            {
                XmlHelper xmlHelper = new XmlHelper();
                GenerationReport genReportInput = xmlHelper.ProcessXmlFile<GenerationReport>(inputFilePath, inputFileName);

                GenerationOutput generationOutput = new GenerationOutput();

                ProcessStats(genReportInput, generationOutput);

                xmlHelper.WriteXmlFile<GenerationOutput>(outputFilePath, outputFileName, generationOutput);
                Console.WriteLine("Output stats file created at - " + outputFilePath + "\\"+ outputFileName);
            }
            catch (Exception ex)
            {
                string message = "Could not process file due to error - " + ex.Message;
                Console.WriteLine(message);
                Logger.LogFatalError(message);
            }
        }

        private static void ProcessStats(GenerationReport genReportInput, GenerationOutput generationOutput)
        {
            Totals totals = new Totals();
            MaxEmissionGenerators maxEmissionGenerators = new MaxEmissionGenerators();
            ActualHeatRates actualHeatRates = new ActualHeatRates();

            totals.Generator = new List<Generator>();
            ProcessWindStats(genReportInput, totals);
            ProcessGasStats(genReportInput, totals, maxEmissionGenerators);
            ProcessCoalStats(genReportInput, totals, maxEmissionGenerators, actualHeatRates);
            generationOutput.Totals = totals;
            MaxEmissionGenerators maxEmissionGeneratorsSorted = RemoveNonHighestEmitters(maxEmissionGenerators);

            generationOutput.MaxEmissionGenerators = maxEmissionGeneratorsSorted;
            generationOutput.ActualHeatRates = actualHeatRates;
        }

        /// <summary>
        /// Process maxEmissionGenerators list. Creating a new list by removing the ones which are not highest
        /// </summary>
        /// <param name="maxEmissionGenerators">Object with all the emmission values for all days of all generators</param>
        /// <returns></returns>
        private static MaxEmissionGenerators RemoveNonHighestEmitters(MaxEmissionGenerators maxEmissionGenerators)
        {
            IList<DataClasses.Output.Day> sortedEmissionDayList = (from emissionDay in maxEmissionGenerators.Day.ToList()
                                                                   orderby emissionDay.Date ascending, emissionDay.Emission descending
                                                                   select emissionDay).ToList();

            DateTime prevEmissionDateTime = sortedEmissionDayList[0].Date;
            double prevDayEmission = sortedEmissionDayList[0].Emission;
            MaxEmissionGenerators maxEmissionGeneratorsSorted = new MaxEmissionGenerators();
            maxEmissionGeneratorsSorted.Day = new List<DataClasses.Output.Day>();
            maxEmissionGeneratorsSorted.Day.Add(sortedEmissionDayList[0]);
            for (int row = 1; row < sortedEmissionDayList.Count; row++)
            {
                if (sortedEmissionDayList[row].Date > prevEmissionDateTime)
                {
                    maxEmissionGeneratorsSorted.Day.Add(sortedEmissionDayList[row]);
                    prevEmissionDateTime = sortedEmissionDayList[row].Date;
                }
            }

            return maxEmissionGeneratorsSorted;
        }

        private static void ProcessCoalStats(GenerationReport genReportInput, Totals totals, MaxEmissionGenerators maxEmissionGenerators, ActualHeatRates actualHeatRates)
        {
            Coal coal = genReportInput.Coal;
            actualHeatRates.ActualHeatRate = new List<ActualHeatRate>();
        
            foreach (var coalGen in coal.CoalGenerator)
            {
                Generator generator = new Generator();
                generator.Name = coalGen.Name;
                double emissionRating = coalGen.EmissionsRating;
                double total = 0.0;

                ActualHeatRate actualHeatRate = new ActualHeatRate();
                actualHeatRate.Name = coalGen.Name;
                actualHeatRate.HeatRate = coalGen.TotalHeatInput / coalGen.ActualNetGeneration;
                actualHeatRates.ActualHeatRate.Add(actualHeatRate);

                foreach (var day in coalGen.Generation.Day)
                {
                    total = total + (day.Energy * day.Price * GlobalReferenceConstants.ValueFactorMedium);

                    //adding all the days for all generators and later removing the ones which are not the highest, since emissions are to be compared across all generators 
                    DataClasses.Output.Day outputday = new DataClasses.Output.Day();
                    outputday.Name = coalGen.Name;
                    outputday.Date = day.Date;
                    outputday.Emission = day.Energy * emissionRating * GlobalReferenceConstants.EmissionFactorHigh;
                    maxEmissionGenerators.Day.Add(outputday);
                }
                generator.Total = total;
                totals.Generator.Add(generator);
            }
        }

        private static void ProcessGasStats(GenerationReport genReportInput, Totals totals, MaxEmissionGenerators maxEmissionGenerators)
        {
            Gas gas = genReportInput.Gas;
            List<Generator> genList = new List<Generator>();
            
            maxEmissionGenerators.Day = new List<DataClasses.Output.Day>();
            foreach (var gasGen in gas.GasGenerator)
            {
                Generator generator = new Generator();
                generator.Name = gasGen.Name;
                double emissionRating = gasGen.EmissionsRating;
                double total = 0.0;
                

                foreach (var day in gasGen.Generation.Day)
                {
                    total = total + (day.Energy * day.Price * GlobalReferenceConstants.ValueFactorMedium);

                    //adding all the days for all generators and later removing the ones which are not the highest, since emissions are to be compared across all generators 
                    DataClasses.Output.Day outputday = new DataClasses.Output.Day();
                    outputday.Name = gasGen.Name;
                    outputday.Date = day.Date;
                    outputday.Emission = day.Energy * emissionRating * GlobalReferenceConstants.EmissionFactorMedium;
                    maxEmissionGenerators.Day.Add(outputday);
                }
                generator.Total = total;
                totals.Generator.Add(generator);
            }
        }

        private static void ProcessWindStats(GenerationReport genReportInput, Totals totals)
        {
            Wind wind = genReportInput.Wind;
            foreach (var windGen in wind.WindGenerator)
            {
                Generator generator = new Generator();
                generator.Name = windGen.Name;
                double total = 0.0;
                double valueFactor = (windGen.Name.Contains("Offshore")) ? GlobalReferenceConstants.ValueFactorLow : GlobalReferenceConstants.ValueFactorHigh;

                foreach (var day in windGen.Generation.Day)
                {
                    total = total + (day.Energy * day.Price * valueFactor);
                }
                generator.Total = total;
                totals.Generator.Add(generator);
            }
        }
    }
}
