using System.Windows;
using System.Windows.Controls;

namespace Fasetto
{
    public class PasswordBoxText
    {

        public static readonly DependencyProperty MoniterPasswordProperty = 
            DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxText), new PropertyMetadata(false, onMonitorPasswordChanged));

        private static void onMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var password = (d as PasswordBox);
            if (password == null)
                return;

            password.PasswordChanged -= Password_PasswordChanged;


            if ((bool)e.NewValue)
            {
                SetHasText(password);
                password.PasswordChanged += Password_PasswordChanged;
            }
            

        }

        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetHasText((PasswordBox)sender);
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
