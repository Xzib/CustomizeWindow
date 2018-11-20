using System.Windows;
using System.Windows.Controls;
namespace Fasetto
{


    public class MonitorPasswordProperty : BaseAttachedProperties<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get the caller
            var passwordBox = sender as PasswordBox;

            //make sure it is a password box
            if (passwordBox == null)
            {
                return;
            }

            //Remove any previous events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged ;

            //if the caller set MonitorPassword to true
            if ((bool)e.NewValue)
            {

                //set default value
                HasTextProperty.SetValue(passwordBox);

                //start listening out for password changed
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }


        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText attached property for the <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperties<HasTextProperty, bool> {
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }

}
