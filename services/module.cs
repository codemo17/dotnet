using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ruslan.prototype.test.services
{
    public class module:Module
    {

        #region overridden

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<contactservice>()
                .As<icontactservice>()
                .SingleInstance();
       
          
        }

        #endregion
    }
}
