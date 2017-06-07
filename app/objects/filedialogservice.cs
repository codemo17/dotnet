using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ruslan.prototype.test.app
{
    public class filedialogservice : ifiledialogservice
    {

        #region ifiledialog service implemented

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string showfileopendialog()
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {

                return dialog.FileName;
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Stream openfile()
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {

                return dialog.OpenFile();
            }
            return null;
        }

        #endregion    
    }
}