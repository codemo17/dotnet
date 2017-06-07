using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ruslan.prototype.test.app.viewmodels
{
    public abstract class navigationviewmodel:pageviewmodel,inavigate
    {

        #region ctor

        public navigationviewmodel()
        {

        }

        #endregion

        #region inavigate implemented

        /// <summary>
        /// 
        /// </summary>
        public ICommand firstcommand
        {
            get
            {
                if (_firstcommand == null)
                    _firstcommand = new command(param => first(), param => canfirst);
                return _firstcommand;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICommand lastcommand
        {
            get
            {
                if (_lastcommand == null)
                    _lastcommand = new command(param => last(), param => canlast);
                return _lastcommand;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICommand previouscommand
        {
            get
            {
                if (_previouscommand == null)
                    _previouscommand = new command(param => previous(), param => canprevious);
                return _previouscommand;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICommand nextcommand
        {
            get
            {
                if (_nextcommand == null)
                    _nextcommand = new command(param => next(), param => cannext);
                return _nextcommand;

            }
        }

        #endregion

        #region pageviewmodel overrridden
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override pageviewmodel refresh()
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region tobeimplemented


        protected abstract void first();
        protected abstract bool canfirst { get; }

        protected abstract void last();
        protected abstract bool canlast { get; }

        protected abstract void next();
        protected abstract bool cannext { get; }

        protected abstract void previous();
        protected abstract bool canprevious { get; }

        public abstract int position { get; set; }
        public abstract int count { get; }



        #endregion

        #region inherent
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<commandviewmodel> navigation
        {
            get
            {
                if (_navigation == null)
                {
                    _navigation = new ObservableCollection<commandviewmodel>(createcommands());
                }

                return _navigation;
            }
        }



        #endregion

        #region  helpers

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<commandviewmodel> createcommands()
        {
            _commands = new List<commandviewmodel>
                       {
                           new commandviewmodel("first",firstcommand),
                           new commandviewmodel("previous",previouscommand),
                           new commandviewmodel("next",nextcommand),
                           new commandviewmodel("last",lastcommand)
                         
                       };

            return _commands;

        } 


        #endregion

        #region fields

        private  List<commandviewmodel> _commands;
        private ObservableCollection<commandviewmodel> _navigation;

        private ICommand _firstcommand;
        private ICommand _lastcommand;
        private ICommand _nextcommand;
        private ICommand _previouscommand;

        #endregion

    }
}
