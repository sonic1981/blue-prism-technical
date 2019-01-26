using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords.Interfaces
{
    public interface IGraphFactory
    {
        ConcurrentDictionary<string, List<string>> BuildGraph(IEnumerable<string> words);
    }
}
