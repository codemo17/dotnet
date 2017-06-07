using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ruslan.prototype.test.app
{
    internal interface inavigate
    {

        ICommand firstcommand { get; }
        ICommand lastcommand { get; }

        ICommand previouscommand { get; }
        ICommand nextcommand { get; }

        int position { get; set; }
        int count { get; }

    }
}