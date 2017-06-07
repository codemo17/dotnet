using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ruslan.prototype.test.app
{
    public class command:ICommand
    {

        #region ctors

        public command(Action<object> execute)
            :this(execute,null)
        {}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canexecute"></param>
        public command(Action<object> execute,Func<object,bool> canexecute  )
        {
            if(execute==null)
            {
                throw new ArgumentNullException("execute parameter can not be null");
            }
            _execute = execute;
            _canexecute = canexecute;

        }
       

        #endregion

       #region icommand implemented
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return (_canexecute == null) || _canexecute(parameter);
   
        }
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        /// <summary>
        /// 
        /// </summary>
        public void raisecanexecutechanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
        #endregion

        #region fields

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canexecute;

        #endregion
    }
}
