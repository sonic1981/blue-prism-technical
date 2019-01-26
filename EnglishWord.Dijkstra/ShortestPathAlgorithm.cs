using EnglishWords.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWord.BreadthFirst
{
    public class ShortestPathAlgorithm : IShortestPathAlgorithm
    {
        public bool TryFindShortestPath(IDictionary<string, List<string>> graph, string startNode, string endNode, out IEnumerable<string> criticalPath)
        {
            criticalPath = null;
            //early sanitiy checks
            if (graph.ContainsKey(startNode) == false)
                return false;
            if (graph.ContainsKey(endNode) == false)
                return false;

            //initialise the visited set with our first node.
            HashSet<string> visitedSet = new HashSet<string>()
            {
                startNode
            };

            IEnumerable<string> edges = graph[startNode];
            
            if (edges.Any() == false)
                return false;

            foreach(string e in edges)
            {
                //skip nodes we've already visited
                if (visitedSet.Contains(e) == false)
                {

                }
            }
        }
    }
}
