using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ruslan.prototype.test.app.helpers
{
    public class dateformatconverter:IValueConverter
    {
        private CultureInfo _provider;
        private string _format;

        public dateformatconverter()
        {
              
        }

        #region ivalueconverter implemented
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

           

            DateTime date;

            if(value!=null && DateTime.TryParseExact(value.ToString(),"dd-MM-yyyy", culture, DateTimeStyles.None, out date))
            {
                return date.ToString();
            }
            return string.Empty;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            DateTime date;

            if (value != null && DateTime.TryParse(value.ToString(), out date))
            {
               return date.ToString("dd-MM-yyyy");
            }
            return string.Empty;
        } 
        #endregion
    }
}
