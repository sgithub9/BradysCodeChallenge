using System;
using System.IO;

namespace PowerGeneratorStats
{
    class FileSystemHelper
    {
        private readonly string inputFilePath;
        private readonly string inputFileName;
        private readonly string outputFilePath;
        private readonly string outputFileName;

        public FileSystemHelper(string inputFilePath, string inputFileName, string outputFilePath, string outputFileName)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(inputFilePath);
            this.inputFileName = inputFileName;
            this.inputFilePath = inputFilePath;
            this.outputFileName = outputFileName;
            this.outputFilePath = outputFilePath;

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastWrite;

            //watcher.Changed += OnChanged;//due to the way in which Windows file system handles files this event is triggered twice for certain files and is not implemented
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            //watcher.Renamed += OnRenamed;//not implemented as part of the application functionality currently

            watcher.Filter = inputFileName;
            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true;

            Logger.LogInfo("File system monitoring started.");            
        }

        //private void OnChanged(object sender, FileSystemEventArgs e)
        //{
            //if ((e.ChangeType != WatcherChangeTypes.Changed))
            //{
            //    return;
            //}

            //Console.WriteLine($"Input file has changed: {e.FullPath}");
            //Logger.LogInfo($"Input file has changed: {e.FullPath}");
            //ProcessGeneratorStats.ProcessInputFile(FilePath, FileName);
        //}

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string message = "Input file Created. Processing and generating the result now.";
            Logger.LogInfo(message);
            Console.WriteLine(message);
            ProcessGeneratorStats.ProcessStats(inputFilePath, inputFileName,outputFilePath,outputFileName);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted: {e.FullPath}");
            Logger.LogInfo($"Deleted: {e.FullPath}");
        }
        
    }
}
