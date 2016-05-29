using System.IO;

namespace Data.Infrostructure
{
    public class FileWriter: IWriter
    {
        private readonly string _fileName;

        public FileWriter(string fileName = "file.txt")
        {
            _fileName = fileName;
        }
        public void Write(string message)
        {
            File.AppendAllText(_fileName, message);
        }
    }
}
