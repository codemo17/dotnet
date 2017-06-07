using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ruslan.prototype.test.app.helpers
{
    public class alphacharsrequiredvalidationrule:ValidationRule
    {
        #region implemented
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var result = ValidationResult.ValidResult;
            var enteredvalue = string.Format("{0}", value);
            
            var patternbuilder = new StringBuilder("[a-zA-Z]");
            if(!Regex.IsMatch(enteredvalue,patternbuilder.ToString()) )
            {
                result = new ValidationResult(false,
                                string.Format("Invalid entry:{0} :only alpha characters are permitted",enteredvalue));

            }
            return result;
        } 
        #endregion
    }
}
