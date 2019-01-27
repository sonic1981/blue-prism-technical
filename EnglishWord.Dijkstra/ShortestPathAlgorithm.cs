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
        public bool TryFindShortestPath(IDictionary<string, List<string>> graph, string startNode, string endNode, out IEnumerable<string> criticalPath)
        {
            //node queue for next objects
            Queue<string> nextNodeQueue = new Queue<string>();

            Dictionary<string, List<string>> visitedEdges = new Dictionary<string, List<string>>();

            nextNodeQueue.Enqueue(startNode);
            criticalPath = new List<string>();

            //Visited set for weighted paths
            Dictionary<string, int> visitedSet = new Dictionary<string, int>();
            visitedSet.Add(startNode, 0);

            //early sanitiy checks
            if (graph.ContainsKey(startNode) == false)
                return false;
            if (graph.ContainsKey(endNode) == false)
                return false;


            //while we have nodes to check
            while (nextNodeQueue.Any())
            {
                string currentNode = nextNodeQueue.Dequeue();
                int currentWeight = visitedSet[currentNode];
                IEnumerable<string> edges = graph[currentNode];

                //dead end if false
                if (edges.Any())
                {
                    //next nodes weight is the sum of the pevious plus one
                    int nextWeight = currentWeight + 1;
                    foreach (string e in edges)
                    {
                        if (visitedSet.ContainsKey(e))
                        {
                            //update if lower
                            if (visitedSet[e] > nextWeight)
                            {
                                addVisitedEdge(visitedEdges, currentNode, e);
                                visitedSet[e] = nextWeight;
                            }
                        }
                        else
                        {
                            addVisitedEdge(visitedEdges, currentNode, e);
                            visitedSet.Add(e, nextWeight);
                            //add to our node queue, not visited
                            nextNodeQueue.Enqueue(e);
                        }
                    }
                }

               
            }

            criticalPath = buildCriticalPath(startNode, endNode, visitedEdges, visitedSet);

            return true;
        }

        private static void addVisitedEdge(Dictionary<string, List<string>> visitedEdges, string currentNode, string e)
        {
            if (visitedEdges.ContainsKey(e))
                visitedEdges[e].Add(currentNode);
            else
            {
                visitedEdges.Add(e, new List<string>() {currentNode });
            }
        }

        private static IEnumerable<string> buildCriticalPath(string startNode, string endNode, Dictionary<string, List<string>> visitedEdges, Dictionary<string, int> visitedSet)
        {
            List<string> criticalPath = new List<string>();
            string currentNode = endNode;
            int currentWeight = visitedSet[endNode];
            while (currentNode != startNode)
            {
                criticalPath.Add(currentNode);
                List<string> visited = visitedEdges[currentNode];
                foreach (string v in visited)
                {
                    if (visitedSet[v] < currentWeight)
                    {
                        currentWeight = visitedSet[v];
                        currentNode = v;
                    }
                }
            }

            criticalPath.Add(startNode);
            criticalPath.Reverse();

            return criticalPath;
        }

    }
}
