using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ruslan.prototype.test.domain;
using ruslan.prototype.test.services;

namespace ruslan.prototype.test.app.viewmodels
{
    public abstract class collectionviewmodel<v,t> :navigationviewmodel where v:class,imodelviewmodel<t>,iselectable,new()
                                                                        where t:class,ientity          
    {
        #region ctor
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public collectionviewmodel(iservice<t> service )
        {

            this.service = service;
            load();


        } 
        #endregion

        #region navigationsviewmodel overridden
        /// <summary>
        /// 
        /// </summary>
        protected override bool canfirst
        {
            get { return items != null && currentpage > 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void first()
        {
            _currentpage = 0;
            raisepropertychanged(() => currentpage);
            raisepropertychanged(() => page);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override bool canlast
        {
            get { return items != null && currentpage < count - 1; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void last()
        {
            _currentpage = count - 1;
            raisepropertychanged(() => currentpage);
            raisepropertychanged(() => page);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override bool cannext
        {
            get { return items != null && _currentpage < count - 1; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void next()
        {
            _currentpage++;
            raisepropertychanged(() => currentpage);
            raisepropertychanged(() => page);
        }
        /// <summary>
        /// 
        /// </summary>
        protected override bool canprevious
        {
            get { return items != null && _currentpage > 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void previous()
        {
            _currentpage--;
            raisepropertychanged(() => currentpage);
            raisepropertychanged(() => page);
        }


      
        #endregion

        #region inherent
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<currentchangedeventargs<v>> currentchanged;
         /// <summary>
        /// 
        /// </summary>
        public multiselectobservablecollection<v> items { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int pagesize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public override int count
        {
            get
            {
                return Convert.ToInt32(Math.Ceiling((decimal)items.Count / pagesize));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int currentpage
        {
            get { return _currentpage + 1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override int position
        {
            get
            {
                return view.CurrentPosition + 1;
            }
            set
            {
                view.MoveCurrentTo(value - 1);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public v cursoritem
        {
            get
            {
                _currentitem = (view != null) ? view.CurrentItem as v : default(v);
                return _currentitem;
            }

            set
            {
                view.MoveCurrentTo(value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<v> page
        {
            get
            {
                return items.Skip(_currentpage * pagesize)
                    .Take(items.Count - (pagesize * _currentpage) < pagesize 
                        ? items.Count - (pagesize * _currentpage) 
                        : pagesize);
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ICollectionView view
        {
            get
            {
                return CollectionViewSource.GetDefaultView(currentpage);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected virtual void oncurrentviewchanged(object sender, EventArgs args)
        {
            if (view == null)
                return;
            raisepropertychanged(() => position);
            raisepropertychanged(() => cursoritem);

            var handler = currentchanged;
            if (handler != null)
            {
                handler(sender, new currentchangedeventargs<v>(cursoritem));
            }
        }
       
        #endregion

        #region tobe impelemented

        abstract protected void itempropertychanged(object sender, PropertyChangedEventArgs e);

        protected iservice<t> service { get; set; }
      


        #endregion

        #region helpers
        /// <summary>
        /// 
        /// </summary>
        protected  void load()
        {
            _collection = service.getall();
            
            map();

         }
        /// <summary>
        /// 
        /// </summary>
        protected  void map( )
        {

            if (_collection != null)
            {
                var vlist = (from t in _collection select new v() { model = t }).ToList();

                foreach (var v in vlist)
                {
                    v.PropertyChanged += itempropertychanged;

                }
                items = new multiselectobservablecollection<v>(vlist);
                onpropertychanged("page");
            }
        }

        #endregion

        #region fields

        protected IList<t> _collection;
        private int _currentpage;
        private v _currentitem;
        

        #endregion


    }
}
