using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Chat_Pro_NCP
{
    

    public class MonitorPasswordPropertys : BaseAttached<MonitorPasswordPropertys, bool>
    {
        public override void OnValueChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox == null)
                return;
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
            if ((bool)e.NewValue)
            {
                HadTextProperty.SetValue(passwordBox);

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HadTextProperty.SetValue((PasswordBox)sender);
        }
    }

    public class HadTextProperty : BaseAttached<HadTextProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}