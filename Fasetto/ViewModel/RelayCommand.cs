using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto
{
    /// <summary>
    /// A basic Command that can run an action
    /// </summary>

    public class RelayCommand : ICommand
    {
        #region PrivateMemebers
        // Action to run
        private Action mAction;
        #endregion

        #region PublicEventHandler
        /// <summary>
        /// the event fired when they <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor
        /// <summary>
        /// Default Contructor
        /// </summary>
        public RelayCommand(Action action) => mAction = action;
        #endregion


        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
