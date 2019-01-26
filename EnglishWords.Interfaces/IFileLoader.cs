using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords.Interfaces
{
    public interface IFileLoader
    {
        IEnumerable<string> LoadFile(string fileName);
    }
}
