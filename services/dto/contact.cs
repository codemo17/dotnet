using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace ruslan.prototype.test.services.dto
{
    [DataContract]
    public class contact
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string lastname { get; set; }
        [DataMember]
        public DateTime? dateofbirth { get; set; }
    }
}
