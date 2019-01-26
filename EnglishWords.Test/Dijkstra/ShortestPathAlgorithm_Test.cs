using EnglishWord.Dijkstra;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords.Test.Dijkstra
{
    [TestFixture]
    public class ShortestPathAlgorithm_Test
    {
        /// <summary>
        /// Basically a test implmentation of the a shortest path
        /// </summary>
        [Test]
        public void FindShortestPath()
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            graph.Add("a", new List<string>() { "b", "c", "b", "d" });
            graph.Add("b", new List<string>() { "a", "g" });
            graph.Add("c", new List<string>() { "a", "d" });
            graph.Add("d", new List<string>() { "c", "e" });
            graph.Add("e", new List<string>() { "d", "g" });
            graph.Add("f", new List<string>() { "g" });
            graph.Add("g", new List<string>() { "a","f", "e" });

            ShortestPathAlgorithm shortestPathAlgorithm = new ShortestPathAlgorithm();
            IEnumerable<string> result = shortestPathAlgorithm.FindShortestPath(graph, "a", "d");
            string[] resultArray = result.ToArray();

            Assert.AreEqual("a", resultArray[0]);
            Assert.AreEqual("c", resultArray[1]);
            Assert.AreEqual("d", resultArray[2]);
        }
    }
}
