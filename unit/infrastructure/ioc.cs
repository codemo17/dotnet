using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace unit.infrastructure
{
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="tmodule"></typeparam>
        public abstract class ioc<tmodule> where tmodule:IModule, new()
        {
        #region setup
		/// <summary>
		/// 
		/// </summary>
        public ioc()
        {

            var builder = new ContainerBuilder();
            builder.RegisterModule(new tmodule());

            _container= builder.Build();
        } 
	    #endregion


       #region resolve
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="t"></typeparam>
		/// <returns></returns>
        protected  t resolve<t>()
        {
            return _container.Resolve<t>();
        }
        #endregion

        #region teardown
        /// <summary>
        /// 
        /// </summary>
		protected void shutdown()
        {
            _container.Dispose();
        } 
	    #endregion 
	
        #region fields
        private readonly IContainer _container;
        #endregion

    }
}

