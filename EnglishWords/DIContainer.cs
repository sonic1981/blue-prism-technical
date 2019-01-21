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
        }

        public Container GetContainer()
        {
            _container.Verify();

            return _container;
        }
    }
}
