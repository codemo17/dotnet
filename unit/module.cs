using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ruslan.prototype.test.app;
using ruslan.prototype.test.app.viewmodels;
using ruslan.prototype.test.infrastructure.repositories;
using ruslan.prototype.test.services;

namespace unit
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
            builder.RegisterType<contactrepository>().
           As<icontactrepository>()
           .WithParameter("datafilepath", "../../data/contacts.xml").SingleInstance();

            builder.RegisterType<contactservice>().As<icontactservice>().SingleInstance();
            builder.RegisterType<filedialogservice>().As<ifiledialogservice>();
            builder.RegisterType<contactviewmodel>();
        

        } 
        #endregion

    }
}
