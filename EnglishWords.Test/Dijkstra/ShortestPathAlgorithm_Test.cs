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
        /// Basically a test implementation of the a shortest path
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
            List<string> result;
            bool found = shortestPathAlgorithm.TryFindShortestPath(graph, "a", "h", out result);
            string[] resultArray = result.ToArray();

            Assert.IsTrue(found);
            Assert.AreEqual(4, resultArray.Count());
            Assert.AreEqual("a", resultArray[0]);
            Assert.AreEqual("g", resultArray[1]);
            Assert.AreEqual("e", resultArray[2]);
            Assert.AreEqual("h", resultArray[3]);
        }

        [Test]
        public void FindShortestPath_DeadNodes()
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            graph.Add("a", new List<string>() { "c", "b", "g" });
            graph.Add("b", new List<string>() { "a", "g" });
            graph.Add("c", new List<string>() { "a", "d" });
            graph.Add("d", new List<string>() { "c", "e", "i" });
            graph.Add("e", new List<string>() { "d", "g", "h", "i" });
            graph.Add("f", new List<string>() { "g" });
            graph.Add("g", new List<string>() { "a", "f", "e" });
            graph.Add("h", new List<string>() { "e" });
            graph.Add("i", new List<string>() { "d", "e" });
            //should be ignored
            graph.Add("j", new List<string>());
            graph.Add("k", new List<string>());

            ShortestPathAlgorithm shortestPathAlgorithm = new ShortestPathAlgorithm();
            List<string> result;
            bool found = shortestPathAlgorithm.TryFindShortestPath(graph, "a", "h", out result);
            string[] resultArray = result.ToArray();

            Assert.IsTrue(found);
            Assert.AreEqual(4, resultArray.Count());
            Assert.AreEqual("a", resultArray[0]);
            Assert.AreEqual("g", resultArray[1]);
            Assert.AreEqual("e", resultArray[2]);
            Assert.AreEqual("h", resultArray[3]);
        }

        [Test]
        public void FindShortestPath_ImpossiblePath()
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            graph.Add("a", new List<string>() { "c", "b", "g" });
            graph.Add("b", new List<string>() { "a", "g" });
            graph.Add("c", new List<string>() { "a", "d" });
            graph.Add("d", new List<string>() { "c", "e", "i" });
            graph.Add("e", new List<string>() { "d", "g", "h", "i" });
            graph.Add("f", new List<string>() { "g" });
            graph.Add("g", new List<string>() { "a", "f", "e" });
            graph.Add("h", new List<string>() { "e" });
            graph.Add("i", new List<string>() { "d", "e" });
            //should be ignored
            graph.Add("j", new List<string>());
            graph.Add("k", new List<string>());

            ShortestPathAlgorithm shortestPathAlgorithm = new ShortestPathAlgorithm();
            List<string> result;
            bool found = shortestPathAlgorithm.TryFindShortestPath(graph, "a", "k", out result);
            string[] resultArray = result.ToArray();

            Assert.IsFalse(found);
        }

        [Test]
        public void FindShortestPath_ImpossiblePath_startAtDeadEnd()
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            graph.Add("a", new List<string>() { "c", "b", "g" });
            graph.Add("b", new List<string>() { "a", "g" });
            graph.Add("c", new List<string>() { "a", "d" });
            graph.Add("d", new List<string>() { "c", "e", "i" });
            graph.Add("e", new List<string>() { "d", "g", "h", "i" });
            graph.Add("f", new List<string>() { "g" });
            graph.Add("g", new List<string>() { "a", "f", "e" });
            graph.Add("h", new List<string>() { "e" });
            graph.Add("i", new List<string>() { "d", "e" });
            //should be ignored
            graph.Add("j", new List<string>());
            graph.Add("k", new List<string>());

            ShortestPathAlgorithm shortestPathAlgorithm = new ShortestPathAlgorithm();
            List<string> result;
            bool found = shortestPathAlgorithm.TryFindShortestPath(graph, "k", "a", out result);
            string[] resultArray = result.ToArray();

            Assert.IsFalse(found);
        }
    }
}
