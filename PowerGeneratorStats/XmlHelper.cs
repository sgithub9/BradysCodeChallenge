using System;
using System.IO;
using System.Xml.Serialization;

namespace PowerGeneratorStats
{
    class XmlHelper
    {
        public T ProcessXmlFile<T>(string filePath, string fileName)
        {
            //File IO ops
            StreamReader file=null;
            T rpt=default(T);
            try
            {
                file = new StreamReader(filePath + "\\" + fileName);
                var serializer = new XmlSerializer(typeof(T));
                rpt = (T)serializer.Deserialize(file);
            }
            catch(FileNotFoundException fileExcp)
            {
                Logger.LogFatalError("The file - "+ fileName + " was not found at the location - " +filePath + ". Error - "+ fileExcp.Message);
                throw fileExcp;
            }
            catch (Exception ex)
            {
                Logger.LogFatalError("There was an exception in processXML method. Error - " + ex.Message);
                throw ex;
            }
            finally
            {
                if(file!=null)
                    file.Close();
            }
            
            return rpt;
        }

        public void WriteXmlFile<T>(string filepath, string filename, T obj)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

            var path = filepath + "//" + filename;
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, obj);
            file.Close();
        }
    }
}
