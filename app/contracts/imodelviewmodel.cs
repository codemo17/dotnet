using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruslan.prototype.test.app
{
    public interface imodelviewmodel<t>:INotifyPropertyChanged 
    {
        t model { get; set; }

    }
}
