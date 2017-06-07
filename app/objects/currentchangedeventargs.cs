using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruslan.prototype.test.app
{
    public  class currentchangedeventargs<v>:EventArgs
    {

        #region ctors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        public currentchangedeventargs(v current)
        {
             this.current = current;
        }

        #endregion

        #region inherent
        /// <summary>
        /// 
        /// </summary>
        public v current { get; set; }

        #endregion
    }
}
