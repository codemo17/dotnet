using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ruslan.prototype.test.domain;

namespace ruslan.prototype.test.services
{
    public interface iservice<t> where t:ientity
    {

        List<t> getall();
        void save(t entity);
        void create(t entity);
        void remove(t entity);

    }
}
