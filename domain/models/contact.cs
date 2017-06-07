using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ruslan.prototype.test.domain.models
{
    public class contact:iaggregateroot,IDataErrorInfo
    {

        #region ctor
        /// <summary>
        /// 
        /// </summary>
        public contact()
            : this(null)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public contact(string id)
        {
            this.id = id?? Guid.NewGuid().ToString("B");
            _errors=new Dictionary<string, string>();
            
            
            
        } 
        #endregion

        #region properties
  
        public string name { get; set; }
        public string lastname { get; set; }
        public string dateofbirth { get; set; }
        public object id { get; private set; }
        public string photo { get; set; }
        public string bio { get; set; }
        #endregion

        #region idataerrorinfo implemented
        /// <summary>
        /// 
        /// </summary>
        public string Error
        {
            get
            {
                
                if(_errors.Count ==0)
                {
                    return null;
                }

                var errorstring = new StringBuilder();
                var erromessages = _errors.Values.GetEnumerator();

                while(erromessages.MoveNext())
                {
                    errorstring.AppendLine(erromessages.Current);
                }

                return errorstring.ToString();

            }
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
                string message = null;
                switch (property)
                {
                        
                    case "dateofbirth":

                         var provider = CultureInfo.InvariantCulture;
                         var format = "dd-MM-yyyy";

                         DateTime dob = DateTime.ParseExact(dateofbirth,format,provider);
                         var age = (int)(DateTime.Now.Subtract(dob).Days / 365.25);
                
                         if (age < 18 || age > 100)
                         {
                            message = "you are under 18 or you could've been lived more a 100 years";
                         }
      
                        break;

                    case "name":
                        message = validate(name);

                        break;

                    case "lastname":
                        message = validate(lastname);
              
                        break;
                    default:
                        message = "wrong field name";
                        break;
                }


                if(!string.IsNullOrEmpty(message)&& !_errors.ContainsKey(property))
                {
                    _errors.Add(property,message);
                    
                }
               
                if (string.IsNullOrEmpty(message) && _errors.ContainsKey(property))
                {
                    _errors.Remove(property);

                }


                return message;

            }
        } 
        #endregion

        #region helpers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string validate(string value)
        {
            var enteredvalue = string.Format("{0}", value);
            var patternbuilder = new StringBuilder("[a-zA-Z]");
            
            if (!Regex.IsMatch(enteredvalue, patternbuilder.ToString()))
            {
                return  "this field is mandatory and only alpha chars are allowed";
            }
           
            return string.Empty;

        }


        #endregion

        #region fields

        private Dictionary<string, string> _errors;

        #endregion
    }
}
