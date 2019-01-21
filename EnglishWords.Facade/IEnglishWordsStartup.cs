﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords.Facade
{
    public interface IEnglishWordsStartup
    {
        Task FindShortestPath(string filePath, string startWord, string endWord, string resultFilePath);
    }
}
