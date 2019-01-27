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
            graph.Add("a", new List<string>() { "c", "b", "g" });
            graph.Add("b", new List<string>() { "a", "g" });
            graph.Add("c", new List<string>() { "a", "d" });
            graph.Add("d", new List<string>() { "c", "e", "i" });
            graph.Add("e", new List<string>() { "d", "g", "h", "i" });
            graph.Add("f", new List<string>() { "g" });
            graph.Add("g", new List<string>() { "a","f", "e" });
            graph.Add("h", new List<string>() { "e" });
            graph.Add("i", new List<string>() { "d", "e" });

            ShortestPathAlgorithm shortestPathAlgorithm = new ShortestPathAlgorithm();
            IEnumerable<string> result;
            bool found = shortestPathAlgorithm.TryFindShortestPath(graph, "a", "h", out result);
            string[] resultArray = result.ToArray();

            Assert.IsTrue(found);
            Assert.AreEqual(4, resultArray.Count());
            Assert.AreEqual("a", resultArray[0]);
            Assert.AreEqual("g", resultArray[1]);
            Assert.AreEqual("e", resultArray[2]);
            Assert.AreEqual("h", resultArray[3]);
        }
    }
}
