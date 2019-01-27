using EnglishWords.FileLibrary;
using EnglishWords.Graph;
using EnglishWords.Interfaces;
using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords.Facade.Imple
{
    public class EnglishWordsStartup : IEnglishWordsStartup
    {
        private readonly IFileLoader _fileLoader;
        private readonly IGraphFactory _graphFactory;
        private readonly ILogger _logger;
        private readonly IShortestPathAlgorithm _shortestPathAlgorithm;

        public EnglishWordsStartup(IFileLoader fileLoader,
            IGraphFactory graphFactory,
            IShortestPathAlgorithm shortestPathAlgorithm,
            ILogger logger)
        {
            _fileLoader = fileLoader;
            _graphFactory = graphFactory;
            _shortestPathAlgorithm = shortestPathAlgorithm;
            _logger = logger;
        }


        public void FindShortestPath(string filePath, string startWord, string endWord, string resultFilePath)
        {
            _logger.Info("Loading file...");
            IEnumerable<string> words = _fileLoader.LoadFile(filePath);
            _logger.Info("File loaded");

            _logger.Info("Building graph...");
            ConcurrentDictionary<string, List<string>>  graph = _graphFactory.BuildGraph(words);
            _logger.Info("Graph built");


            int numberOfMatching = graph.Count(c => c.Value.Any());
            _logger.Info($"system has found {numberOfMatching} dead end nodes of {graph.Count()}");

            //_shortestPathAlgorithm.FindShortestPath(graph, startWord, endWord);
            throw new NotImplementedException();
        }
    }
}
