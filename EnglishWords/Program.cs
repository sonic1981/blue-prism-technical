﻿using EnglishWords.Facade;
using NLog;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DIContainer diFactory = new DIContainer();
            using (Container container = diFactory.GetContainer())
            {
                ILogger logger = container.GetInstance<ILogger>();
                try
                {
                    logger.Info("Starting....");

                    IEnglishWordsStartup startup = container.GetInstance<IEnglishWordsStartup>();
#if DEBUG
                    await startup.FindShortestPath(args[0],string.Empty, string.Empty, string.Empty);
#endif
#if !DEBUG
                    await startup.FindShortestPath(args[0], args[1], args[2], args[3]);

#endif

                    logger.Info("Complete");

                }
                catch(Exception ex)
                {
                    logger.Error(ex);
                    Console.ReadLine();
                }
            }
        }
    }
}
