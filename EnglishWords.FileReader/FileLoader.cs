using EnglishWords.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords.FileLibrary
{
    public class FileLoader : IFileLoader
    {
        public IEnumerable<string> LoadFile(string fileName)
        {
            try
            {
                return File.ReadAllLines(fileName);
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Failed to read file {fileName}", ex);
            }
        }

        public void SaveFile(IEnumerable<string> criticalPath, string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                File.WriteAllLines(fileName, criticalPath);
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Failed to write to file {fileName}", ex);
            }
        }
    }
}
