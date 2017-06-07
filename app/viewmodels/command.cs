using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ruslan.prototype.test.app.viewmodels
{
    public class commandviewmodel : viewmodel
    {

        #region ctors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="displayname"></param>
        /// <param name="command"></param>
        public commandviewmodel(string displayname, ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            this.displayname = displayname;
            _command = command;
        }

       


        #endregion

        #region interface

        /// <summary>
        /// 
        /// </summary>
        public virtual string tooltip
        {
            get { return _tooltip; }
            protected set { _tooltip = value;onpropertychanged("tooltip"); }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public ICommand command
        {
            get { return _command; }
            private set { _command = value; }
        }
        #endregion

        #region fields

        private ICommand _command;
        private string _tooltip;
       
        #endregion

    }
}
