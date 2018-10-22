using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto
{
    public class WindowViewModel : BaseClass
    {

        /// <summary>
        /// The Window this view model controls
        /// </summary>
        #region Private Members

        private Window mWindow;

        #endregion

        #region Public Properties
        public string Test { get; set; }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>

        #region Constructer

        public WindowViewModel(Window window)
        {
            mWindow = window;
        }
        #endregion
    }
}
