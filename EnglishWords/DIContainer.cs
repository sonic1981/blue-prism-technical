using EnglishWords.Facade;
using EnglishWords.Facade.Imple;
using EnglishWords.FileLibrary;
using EnglishWords.Graph;
using EnglishWords.Interfaces;
using NLog;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords
{
    public class DIContainer
    {
        private readonly Container _container;

        public DIContainer()
        {
            _container = new Container();
            SetDefaultScope();
            RegisterTypes();
        }

        public  void SetDefaultScope()
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }

        public virtual void RegisterTypes()
        {
            _container.Register<ILogger>(() => LogManager.GetLogger(""));

            _container.Register<IEnglishWordsStartup, EnglishWordsStartup>();
            _container.Register<IFileLoader, FileLoader>();
            _container.Register<IGraphFactory, GraphFactory>();
        }

        public Container GetContainer()
        {
            _container.Verify();

            return _container;
        }
    }
}
