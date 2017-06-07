using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ruslan.prototype.test.domain;
using ruslan.prototype.test.domain.models;

namespace ruslan.prototype.test.services
{
    public interface icontactservice :iservice<contact>
    {
        List<contact> getall();
        void create(contact contact);
        void save(contact contact);
        void remove(contact contact);
        
    }
}
