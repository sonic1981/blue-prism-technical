﻿using EnglishWords.Graph;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords.Test.Graph
{
    [TestFixture]
    public class GraphFactory_Test
    {
        [Test]
        public void BuildGraph()
        {
            List<string> testData = new List<string>()
            {
                "agne",
                "agnes",
                "agnew",
                "abnes"
            };

            GraphFactory factory = new GraphFactory();

            ConcurrentDictionary<string, List<string>> result = factory.BuildGraph(testData);

            Assert.IsTrue(result["agne"].Any(a => a == "agnes"));
            Assert.IsTrue(result["agne"].Any(a => a == "agnew"));
        }

        [Test]
        public void IsOneCharacterDifferent()
        {
            GraphFactory factory = new GraphFactory();
            Assert.IsTrue(factory.IsOneCharacterDifferent("agne", "agnes"));
            Assert.IsFalse(factory.IsOneCharacterDifferent("agne", "abnes"));
            Assert.IsTrue(factory.IsOneCharacterDifferent("agnew", "agnes"));
            Assert.IsFalse(factory.IsOneCharacterDifferent("agnew", "adasddsfsdfsf"));
            Assert.IsTrue(factory.IsOneCharacterDifferent("agnes", "agne"));
        }

        [Test]
        public void IncorrectResultsReturned()
        {
            GraphFactory factory = new GraphFactory();
            List<string> input = new List<string>()
            {
                "supernatant",
                "s",
                "super"
            };
            ConcurrentDictionary<string, List<string>> result = factory.BuildGraph(input);

            Assert.AreEqual(3, result.Count());
            List<string> edges;
            Assert.IsTrue(result.TryGetValue("supernatant", out edges));
            Assert.IsFalse(edges.Any());
        }

    }
}
