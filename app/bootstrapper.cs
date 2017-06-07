using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using ruslan.prototype.test.app.viewmodels;

namespace ruslan.prototype.test.app
{
    public class bootstrapper:IDisposable
    {
        #region ctors
        /// <summary>
        /// default ctor
        /// </summary>
        public bootstrapper()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ConfigurationSettingsReader>();
            _container = builder.Build();

        }

        #endregion


        #region getters
        /// <summary>
        /// 
        /// </summary>
        public mainviewmodel main
        {
            get { return _container.Resolve<mainviewmodel>(); }
        }


        #endregion

        #region idisposable implemented
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _container.Dispose();
            _container = null;
        }
        
        #endregion
        #region fields

        private IContainer _container;

        #endregion


    }
}
