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
            return File.ReadAllLines(fileName);
        }


    }
}
