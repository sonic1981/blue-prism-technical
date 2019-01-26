using EnglishWords.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWord.Dijkstra
{
    public class ShortestPathAlgorithm : IShortestPathAlgorithm
    {
        public IEnumerable<string> FindShortestPath(ConcurrentDictionary<string, List<string>> graph, string startNode, string endNode)
        {
            throw new NotImplementedException();
        }
    }
}
