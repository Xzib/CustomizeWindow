using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PropertyChanged;
namespace Fasetto
{
    /// <summary>
    /// A base view model that fires property changed event as needed 
    /// </summary>
    [ImplementPropertyChanged]
    public class BaseClass : INotifyPropertyChanged
    {
        /// <summary>
        /// the event that is fired when any child property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));

        }
    }
}
