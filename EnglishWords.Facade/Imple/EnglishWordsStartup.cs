using EnglishWords.FileLibrary;
using EnglishWords.Graph;
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
        public EnglishWordsStartup(IFileLoader fileLoader,
            IGraphFactory graphFactory)
        {
            _fileLoader = fileLoader;
            _graphFactory = graphFactory;
        }


        public async Task FindShortestPath(string filePath, string startWord, string endWord, string resultFilePath)
        {
            IEnumerable<string> words = _fileLoader.LoadFile(filePath);
            ConcurrentDictionary<string, List<string>>  graph = _graphFactory.BuildGraph(words);
            throw new NotImplementedException();
        }
    }
}
