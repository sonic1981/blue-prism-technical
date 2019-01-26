using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords.Interfaces
{
    public interface IShortestPathAlgorithm
    {
        bool TryFindShortestPath(IDictionary<string, List<string>> graph, string startNode, string endNode, out IEnumerable<string> criticalPath);
    }
}
