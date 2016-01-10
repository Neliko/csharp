using System;
using System.IO;

namespace HomeWork.Infrastructure
{
    class FileLogger : ILogger
    {
        private readonly string _fileName;

        public FileLogger(string fileName = "log.txt")
        {
            _fileName = fileName;
        }

        public void Log(Exception e)
        {
            File.AppendAllText( _fileName , e.Message);
        }
    }
}
