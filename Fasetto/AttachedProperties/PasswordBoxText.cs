using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.AttachedProperties
{
    public class PasswordBoxText
    {

        public static readonly DependencyProperty MoniterPasswordProperty = 
            DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxText), new PropertyMetadata(false, onMonitorPasswordChanged));

        private static void onMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        public static void SetMonitorPassword(PasswordBox element, bool value)

        {
            element.SetValue(MoniterPasswordProperty, value);
        }


        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool)element.GetValue(MoniterPasswordProperty);
        }







        public static readonly DependencyProperty HasTextProperty = 
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxText), new PropertyMetadata(false));
       
        private static void SetHasText(PasswordBox element)
        {
            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
        }

        public static bool GetHasText(PasswordBox element)
        {
            return (bool)element.GetValue(HasTextProperty);

        }
    }
}
