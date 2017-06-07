using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ruslan.prototype.test.app.viewmodels;

namespace ruslan.prototype.test.app
{
    public class module:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<filedialogservice>().As<ifiledialogservice>().SingleInstance();
            builder.RegisterType<mainviewmodel>().SingleInstance();
            builder.RegisterType<defaultviewmodel>();
            builder.RegisterType<contactviewmodel>();
            builder.RegisterType<contactscollectionviewmodel>();

        }
    }
}
