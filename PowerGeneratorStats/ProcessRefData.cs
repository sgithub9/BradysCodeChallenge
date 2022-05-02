using DataClasses.Input;

namespace PowerGeneratorStats
{
    class ProcessRefData
    {     
        public static ReferenceData ProcessAndGetRefData(string filePath, string fileName)
        {
            XmlHelper xmlHandler = new XmlHelper();
            ReferenceData referenceData = xmlHandler.ProcessXmlFile<ReferenceData>(filePath,fileName);
            return referenceData;
        }
            
    }
}
