using EnglishWords.Facade;
using NLog;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords
{
    class Program
    {
        static void Main(string[] args)
        {
            DIContainer diFactory = new DIContainer();
            using (Container container = diFactory.GetContainer())
            {
                ILogger logger = container.GetInstance<ILogger>();
                validateArgs(args, logger);

                try
                {
                    logger.Info("Starting....");

                    IEnglishWordsStartup startup = container.GetInstance<IEnglishWordsStartup>();
                    startup.FindShortestPath(args[0], args[1], args[2], args[3]);


                    logger.Info("Complete");

                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    Console.ReadLine();
                }
            }
        }

        private static void validateArgs(string[] args, ILogger logger)
        {
            if (args == null || args.Count() < 4)
                throw new ArgumentNullException($"Incorrect parameters: EnglishWords filePath startWord endWord saveFilePath");
            else if (string.IsNullOrEmpty(args[0]))
                throw new ArgumentNullException($"Incorrect parameters: EnglishWords filePath startWord endWord saveFilePath",
                    new ApplicationException("filePath is null"));
            else if (string.IsNullOrEmpty(args[1]))
                throw new ArgumentNullException($"Incorrect parameters: EnglishWords filePath startWord endWord saveFilePath",
                    new ApplicationException("startWord is null"));
            else if (string.IsNullOrEmpty(args[2]))
                throw new ArgumentNullException($"Incorrect parameters: EnglishWords filePath startWord endWord saveFilePath",
                    new ApplicationException("endWord is null"));
            else if (string.IsNullOrEmpty(args[3]))
                throw new ArgumentNullException($"Incorrect parameters: EnglishWords filePath startWord endWord saveFilePath",
                    new ApplicationException("saveFilePath is null"));

            if (File.Exists(args[0]) == false)
                throw new ApplicationException($"Cannot find the file {args[0]}");

            if (File.Exists(args[3]))
            {
                logger.Warn($"File {args[3]} exists do you wish to overrite? y/n");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == 'n')
                    throw new ApplicationException("Terminating program, no overwrite");
                else if (key.KeyChar != 'y')
                {
                    throw new ApplicationException("Invalid option");
                }
            }
        }
    }
}
