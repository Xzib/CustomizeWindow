

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fasetto
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members
        // A single static instance of the value converter

        private static T mConverter = null;

        #endregion



        #region MarkupExtension
        /// <summary>
        /// Provide a static instance of the value converter 
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (mConverter == null)
                mConverter = new T();

            return mConverter;

            // return mConverter ?? (mConverter = newT());

        }

        #endregion



        #region value converter methods
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
     
        #endregion
    }
}
