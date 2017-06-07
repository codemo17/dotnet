using System;
using System.Collections.Generic;
using System.Windows.Input;
using ruslan.prototype.test.services;
using System.Linq;
using System.Linq.Expressions;

namespace ruslan.prototype.test.app.viewmodels
{
    public class mainviewmodel:pageviewmodel
    {

        #region ctor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactservice"></param>
        public mainviewmodel(icontactservice contactservice,
            defaultviewmodel defaultviewmodel,
            contactviewmodel contactviewmodel,
            contactscollectionviewmodel contactcollectionviewmodel)
        {
            icon = "/artifacts/images/logo.jpg";
            iconheight = 100;
            iconwidth = 100;
            _contactservice = contactservice;
            // a bit ugly way of hooking event handlers
            contactviewmodel.saved += (s, e) => { content = pages.Where(x => x.displayname.Equals("allcontacts")).First().refresh(); };
            contactcollectionviewmodel.editting += (s, e) =>
                                                       {
                                                          var contacollection = s as contactscollectionviewmodel;
                                                          var contact = pages.Single(x => x.displayname.Equals("new contact")) as contactviewmodel;

                                                          if(contact != null && contacollection != null)
                                                          {
                                                              contact.model = contacollection.current.model;
                                                              content = contact;
                                                          }
                                                                    
                                                                      
                                                       };
            contactviewmodel.close +=close;
            contactcollectionviewmodel.close += close;
            content = defaultviewmodel;
            
            pages = new List<pageviewmodel>
                        {
                         
                            defaultviewmodel,
                            contactviewmodel,
                            contactcollectionviewmodel
               

                        };

           
    
        }
        

        #endregion



        #region properties
        /// <summary>
        /// 
        /// </summary>
        public List<pageviewmodel> pages { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public pageviewmodel content
        {
            get { return _content; }
            set { _content = value; onpropertychanged("content"); }
        }

        public int selected
        {
            get { return _selected; }
            set { _selected = value; onpropertychanged("selected"); }
        }

        #endregion

        #region pageviewmodel implemented
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override pageviewmodel refresh()
        {
            return this;
        }

        #endregion

        #region commands
        /// <summary>
        /// 
        /// </summary>
        public ICommand navigatecommand
        {
            get
            {
                
                _navigatecommand = _navigatecommand??  new command(param =>
                {
                   content = param as pageviewmodel;
                     if (content != null)
                         content.refresh();
           
                });

                return _navigatecommand;
            }


        }

        #endregion

        #region helpers
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void close(object sender, EventArgs e)
       {
           content = pages.Single(x => x.displayname.Equals("info"));

       } 
        #endregion
        

        #region fields

        private readonly icontactservice _contactservice;
        private ICommand _navigatecommand;
        private int _selected;
        private pageviewmodel _content;
        
        #endregion



    }
}
