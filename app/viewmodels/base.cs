using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ruslan.prototype.test.app.utils;

namespace ruslan.prototype.test.app.viewmodels
{
    public abstract class viewmodel:INotifyPropertyChanged,IDisposable 
    {
        #region inotifypropertychanged implemented 
        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyname"></param>
        protected virtual void onpropertychanged(string propertyname)
        {
            var handler = PropertyChanged;
            if(handler!=null)
            {
                var e = new PropertyChangedEventArgs(propertyname);
                handler(this, e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="property"></param>
        protected virtual void raisepropertychanged<t>(Expression<Func<t>> property)
        {
            var handler = PropertyChanged;
            if(handler!=null)
            {
                handler(this, property.createpropertychangedeventargs());
            }

        }

        #endregion

        #region idiposable implemented
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            ondispose();
        } 

        protected virtual void ondispose()
        {}
        #endregion

        #region modelspecific
        /// <summary>
        /// 
        /// </summary>
        public string displayname
        {
            get { return _displayname; }
            set { _displayname = value; onpropertychanged("displayname"); }
        }


        /// <summary>
        /// 
        /// </summary>
        public string icon
        {
            get { return _icon; }
            set { _icon = value; onpropertychanged("icon"); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int iconheight
        {
            get { return _iconheight; }
            set { _iconheight = value; onpropertychanged("iconheight"); }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iconwidth
        {
            get { return _iconwidth; }
            set { _iconwidth = value; onpropertychanged("iconwidth"); }
        }



        #endregion
        #region fields
        private string _displayname;
        private string _icon;
        private int _iconheight;
        private int _iconwidth;
      
       
        #endregion
    }
}
