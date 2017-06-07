using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruslan.prototype.test.app
{
    public interface ifiledialogservice
    {

        string showfileopendialog();
        Stream openfile();
    }
}
