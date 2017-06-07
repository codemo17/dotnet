using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ruslan.prototype.test.app.helpers
{
    public class stringformatconverter:IValueConverter
    {

        #region MyRegion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            var enteredvalue = string.Format("{0}", value);

            var patternbuilder = new StringBuilder("[a-zA-Z]");
            if (!Regex.IsMatch(enteredvalue, patternbuilder.ToString()))
            {
                return " ";
            }

            return value;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var enteredvalue = string.Format("{0}", value);

            var patternbuilder = new StringBuilder("[a-zA-Z]");
            if (!Regex.IsMatch(enteredvalue, patternbuilder.ToString()))
            {
                return " ";
            }

            return value;

        } 
        #endregion
    }
}
