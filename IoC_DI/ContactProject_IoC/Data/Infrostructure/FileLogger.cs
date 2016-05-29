using System;
using System.IO;

namespace Data.Infrostructure
{
    public class FileLogger:ILogger
    {
        private readonly string _fileName;

        public FileLogger(string fileName = "log.txt")
        {
            _fileName = fileName;
        }

        public void Log(Exception e)
        {
            File.AppendAllText(_fileName, e.Message);
        }
    }
}
