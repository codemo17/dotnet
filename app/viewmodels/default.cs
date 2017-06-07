using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruslan.prototype.test.app.viewmodels
{
    public class defaultviewmodel:pageviewmodel
    {
        #region ctors
        /// <summary>
        /// 
        /// </summary>
        public defaultviewmodel()
        {
            displayname = "info";
           
            icon = "/artifacts/images/info.png";
            iconheight = 32;
            iconwidth = 32;

        } 
        #endregion
        

        #region pageviewmodel impelemented
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override pageviewmodel refresh()
        {
            return this;
        } 
        #endregion
    }
}
