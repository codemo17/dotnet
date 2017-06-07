using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ruslan.prototype.test.domain;

namespace ruslan.prototype.test.infrastructure.repositories
{
    public interface irepository<t> where t:iaggregateroot
    {

        void add(t aggregate);
        t single(string id);
        List<t> all();
        void remove(t aggregate);

    }
}
