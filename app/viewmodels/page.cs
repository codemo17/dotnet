using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ruslan.prototype.test.app.viewmodels
{
    public abstract class pageviewmodel:viewmodel,ishutdown
    {



        #region ishutdown implemented
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler close;
        /// <summary>
        /// 
        /// </summary>
        public ICommand closecommand
        {
            get
            {
               return  _closecommand = _closecommand ?? new command(
                                                     param =>
                                                         {
                                                             var handler = close;
                                                             if (handler != null)
                                                             {
                                                                 handler(this, EventArgs.Empty);
                                                             }
                                                         }
          
                                        );
                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract pageviewmodel refresh(); 

        #endregion

        #region properties
  
        
        
        #endregion

        #region tobeoverridden
     
      

        #endregion

        #region fields

        private ICommand _closecommand;
      
        #endregion
    

}
}
