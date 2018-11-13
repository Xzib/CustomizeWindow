using System;
using System.Windows;

namespace Fasetto
{
    public abstract class BaseAttachedProperties<Parent, Property>
        where Parent : BaseAttachedProperties<Parent, Property>, new()    
    {

        #region Public Events
        public event Action<DependencyObject,DependencyPropertyChangedEventArgs> ValueChanged = (sender , e) => {};
        #endregion

        #region Public Properties
        public static Parent Instance { get; set; } = new Parent();
        #endregion

        #region AttachedProperty
        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached
            ("Value", typeof(bool), typeof(BaseAttachedProperties<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnPropertyChanged)));

        /// <summary>
        /// The CallBack Event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that had its property Changed</param>
        /// <param name="e">The arguments for the event</param>
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            //Call the parent function
            Instance.OnValueChanged(d, e);

            //call event listeners
            Instance.ValueChanged(d,e);   
        }

        /// <summary>
        /// gets the value of the attached property
        /// </summary>
        /// <param name="d">the element to get the property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// sets the vale of the attached property
        /// </summary>
        /// <param name="d">the element to get the property from</param>
        /// <param name="value">the value to set the property to</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region EventMethods
        /// <summary>
        /// the method that is called when any property of this type changes
        /// </summary>
        /// <param name="d">The UI element that this property was changed for</param>
        /// <param name="e">the argument for this event</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }
        #endregion

    }
}
