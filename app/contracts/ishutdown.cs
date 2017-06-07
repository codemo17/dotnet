using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ruslan.prototype.test.app.viewmodels;

namespace ruslan.prototype.test.app
{
    public interface ishutdown
    {
        event EventHandler close;
        ICommand closecommand { get; }
        pageviewmodel refresh();

    }
}
