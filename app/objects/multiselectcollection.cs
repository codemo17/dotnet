using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruslan.prototype.test.app
{
    public class multiselectobservablecollection<t> : ObservableCollection<t> where t : iselectable
    {
        /// </summary>
        /// <param name="list"></param>
        public multiselectobservablecollection(List<t> list)
            : base(list)
        {}


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<t> selected
        {
            get { return this.Where(x => x.iselected); }
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<t> all
        {
            get { return this.Select(x => x); }
        }


    }

    
}
