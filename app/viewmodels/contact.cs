using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ruslan.prototype.test.domain.models;
using ruslan.prototype.test.services;

namespace ruslan.prototype.test.app.viewmodels
{
    public class contactviewmodel:pageviewmodel,imodelviewmodel<contact>,iselectable,IDataErrorInfo
    {
        #region ctors
        /// <summary>
        /// 
        /// </summary>
        public contactviewmodel()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public contactviewmodel(ifiledialogservice dialogservice, icontactservice contactservice)
        {
            _filedialogservice = dialogservice;
            _contactservice = contactservice;

            model=new contact();
           
            
            icon = "/artifacts/images/contact_white.png";
            displayname = "new contact";
            iconheight = 32;
            iconwidth = 32;


        }

        

        #endregion

        #region pageviewmodel implemented
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override pageviewmodel refresh()
        {
            model = new contact();
            return this;
        } 
        #endregion

        #region imodelviewmodel<t> implemented

        /// <summary>
        /// 
        /// </summary>
        public virtual contact model
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

        private contact _model;

        #endregion

        #region commands
        /// <summary>
        /// 
        /// </summary>
        public command openfiledialogcommand
        {
            get
            {
                if(_openfiledialogcommand==null)
                {
                    _openfiledialogcommand = new command(param => openfiledialogdialog());
                }

                return _openfiledialogcommand;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public command savecontactcommand
        {
            get
            {
                if (_savecontactcommand == null)
                {
                    _savecontactcommand = new command(param => savecontact(),
                        param=>string.IsNullOrEmpty(Error));
                }

                return _savecontactcommand;


            }

        }

        /// <summary>
        /// 
        /// </summary>
        public command clearcommand
        {
            get
            {
                if (_clearcommand == null)
                {
                    _clearcommand = new command(param =>
                                                    {
                                                        model.name = string.Empty;
                                                        model.lastname = string.Empty;
                                                        model.dateofbirth = string.Empty;
                                                        onpropertychanged("model");
                                                    });
                }

                return _clearcommand;


            }

        }
        

        #endregion

        #region eventhandlers

        public event EventHandler saved;

       
        #endregion

        #region properties
        /// <summary>
        /// 
        /// </summary>
    
        public string dateofbirth
        {
            get { return model.dateofbirth; }
            set
            {
                _dateofbirth = value;
                propertychanged("dateofbirth");
          
                

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            get { return model.name; }
            set { model.name = value; propertychanged("name"); }

        }
        /// <summary>
        /// 
        /// </summary>
        public string lastname
        {
            get { return model.lastname; }
            set { model.lastname = value; propertychanged("lastname");  }

        }
        #endregion

        #region helpers
        /// <summary>
        /// 
        /// </summary>
        private void openfiledialogdialog()
        {

            model.photo = _filedialogservice.showfileopendialog();
            raisepropertychanged(()=>model);
              
        }

        /// <summary>
        /// 
        /// </summary>
        private void savecontact()
        {
            try
            {
                _contactservice.create(model);
                var handler = saved;
                if(handler!=null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
            catch
            {
                this.refresh();
            }
        }

        #endregion

        #region idataerrorinfo overrridden
        /// <summary>
        /// 
        /// </summary>
        public string Error
        {
            get { return model.Error + _error; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string property]
        {
            get
           {
                  if(property =="dateofbirth")
                  {
                 
                       DateTime dob;
                       _error = validate(out dob);
                 
                       if(_error!=null)
                       {

                           return _error ;

                       }
                       model.dateofbirth = dob.ToString("dd-MM-yyyy");
          
                    }

               
               var message = model[property];
               savecontactcommand.raisecanexecutechanged();
               
                return message;


           }

        }
        #endregion

        #region iselectable implemented

        /// <summary>
        /// 
        /// </summary>
        public bool iselected
        {
            get { return _iselected; }
            set { _iselected = value; onpropertychanged("iselected"); }
        }
        #endregion

        #region helpers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dob"></param>
        /// <returns></returns>
        private string validate(out DateTime dob)
        {
            string message = null;
            
            var provider = CultureInfo.InvariantCulture;
            var format = "dd-MM-yyyy";

           
            if(string.IsNullOrEmpty(_dateofbirth))
            {
                message = "date of birth is required field";
          
            }

           
             
            if (!DateTime.TryParseExact(_dateofbirth,format, provider,DateTimeStyles.None , out dob))
            {
                message = "date value is incorrect";
            }

            return message;


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        void propertychanged(string property)
        {

            onpropertychanged(property);
            onpropertychanged("Error");
          

            
        }
        #endregion

        #region fields

        private readonly ifiledialogservice _filedialogservice;
        private readonly icontactservice _contactservice;
        private command _openfiledialogcommand;
        private command _savecontactcommand;
        private command _clearcommand;
        private string _dateofbirth;
        private bool _iselected;
        private string _error;


        #endregion


    }
}
