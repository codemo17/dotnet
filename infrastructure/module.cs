using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ruslan.prototype.test.infrastructure.repositories;

namespace ruslan.prototype.test.infrastructure
{
    public class module:Module
    {

        #region overridden
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            base.Load(builder);
            builder.RegisterType<contactrepository>()
                .As<icontactrepository>()
                .WithParameter("datafilepath", "../../data/contacts.xml");

      
        } 
        #endregion

    }
}
