using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using System.Linq.Expressions;

using ruslan.prototype.test.domain.models;
using ruslan.prototype.test.services;

namespace ruslan.prototype.test.app.viewmodels
{
    public class contactscollectionviewmodel : collectionviewmodel<contactviewmodel,contact>
    {
        #region ctors
        /// <summary>
        /// 
        /// </summary>
        public contactscollectionviewmodel(icontactservice contactservice):base(contactservice)
        {
            icon = "/artifacts/images/contacts_white.png";
            displayname = "allcontacts";
            iconheight = 32;
            iconwidth = 32;
            pagesize = 10;
       }

      
        #endregion

        #region pageviewmodel implemented
        /// <summary>
        /// e
        /// </summary>
        /// <returns></returns>
        public override pageviewmodel refresh()
        {
            load();
            return this;

        }
        #endregion

        #region commands
        /// <summary>
        /// 
        /// </summary>
        public ICommand editcommand
        {
            get
            {
                if(_editcommand==null)
                {
                    _editcommand = new command(param => loadcurrent());
                }

                return _editcommand;

            }
        }


        /// <summary>
        /// 
        /// </summary>
        public ICommand removecommand
        {
            get
            {
                if (_removecommand == null)
                {
                    _removecommand = new command(param =>remove());
                }

                return _removecommand;

            }
        }

        #endregion

        #region collectionviewmodel overridden
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void itempropertychanged(object sender, PropertyChangedEventArgs e)
        {
            var current = sender as contactviewmodel;
            
            if (current != null)
            {
                var model = current.model;


                var selected = items.selected.Where(x => x.model != model);
                foreach (var select in selected)
                {
                    select.PropertyChanged -= itempropertychanged;
                    select.iselected = false;
                    select.PropertyChanged += itempropertychanged;

                }

                this.current = current.iselected?current:null;
            }
        } 
        #endregion
        
        #region eventhandlers

        public event EventHandler editting;
        
        #endregion

        #region inherent
        /// <summary>
        /// 
        /// </summary>
        public contactviewmodel current
        {
            get { return _current; }
            set { _current = value; onpropertychanged("current"); }
        }

        #endregion

        #region helpers

        private void remove()
        {  
            try
            {
                service.remove(current.model);
                current = null;
                load();
            }
            catch
            {
                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void loadcurrent()
        {
            if(current!=null )
            {
                var handler = editting;
                if(handler!=null)
                {
                    handler(this, EventArgs.Empty);

                }
            }
            
        }
        
        #endregion

        #region fields

        private ICommand _editcommand;
        private ICommand _removecommand;
        private contactviewmodel _current;
     
        #endregion
    }
}
