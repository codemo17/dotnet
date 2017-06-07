using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruslan.prototype.test.app.viewmodels
{
    public class modelviewmodel<t> : viewmodel, imodelviewmodel<t> where t : class, new()
    {
        #region ctors

        /// <summary>
        /// 
        /// </summary>
        public modelviewmodel(t model)
        {
            _model = model;
        }

        #endregion
    
        #region imodelviewmodel<t> implemented

        /// <summary>
        /// 
        /// </summary>
        public virtual t model
        {
            get { return _model; }
            set
            {
                _model = value;
                raisepropertychanged(() => model);
            }
        }

        #endregion

        #region fields

        private t _model;

        #endregion

    }

}
