using DataClasses.Input;
using System;
using System.Configuration;


namespace PowerGeneratorStats
{
    class PowerGeneratorStats
    {
        static void Main(string[] args)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string inputFilePath = appSettings["inputfilepath"];
                string inputFileName = appSettings["inputfilename"];
                string refInputFileName = appSettings["refinputfilename"];
                string outputFilePath = appSettings["outputfilepath"];
                string outputFileName = appSettings["outputfilename"];

                Console.WriteLine("This is PowerGeneratorStats application. Messages related to input and output file processing would be displayed on the console.");

                Console.WriteLine("The application would be monitoring the file location - '" + inputFilePath + "' for the file - '" + inputFileName + "'");

                Console.WriteLine("Processing reference data file located - '" + inputFilePath + "\\" + refInputFileName + "'");
                ReferenceData refData = ProcessRefData.ProcessAndGetRefData(inputFilePath, refInputFileName);
                SetRefDataToGlobalVar(refData);

                //Currently FileSystemHelper is used to invoke the input and output file processing on its OnCreated event handler
                FileSystemHelper fileSysHelper = new FileSystemHelper(inputFilePath, inputFileName, outputFilePath, outputFileName);

                Console.WriteLine();//extra line for emphasis of the below message
                Console.WriteLine("******Press any key to exit the application.*********");
                Console.WriteLine();//extra line for emphasis of the above message
                Console.Read();
            }
            catch (Exception ex)
            {
                Logger.LogError("There was an exception - "+ex.Message);;
            }
        }

        private static void SetRefDataToGlobalVar(ReferenceData refData)
        {
            GlobalReferenceConstants.ValueFactorHigh = refData.Factors.ValueFactor.High;
            GlobalReferenceConstants.ValueFactorLow = refData.Factors.ValueFactor.Low;
            GlobalReferenceConstants.ValueFactorMedium = refData.Factors.ValueFactor.Medium;

            GlobalReferenceConstants.EmissionFactorHigh = refData.Factors.EmissionsFactor.High;
            GlobalReferenceConstants.EmissionFactorLow = refData.Factors.EmissionsFactor.Low;
            GlobalReferenceConstants.EmissionFactorMedium = refData.Factors.EmissionsFactor.Medium;
        }
    }
}
