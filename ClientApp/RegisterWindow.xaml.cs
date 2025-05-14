using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimize_Button(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ThemeButton_IsChecked(object sender, RoutedEventArgs e)
        {
            // тут реалізувати зміну теми
            if (LightRadioButton.IsChecked == true)
            {
                Background = new SolidColorBrush(Colors.White);
                Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Register_Button(object sender, RoutedEventArgs e)
        {
            // тут реалізувати реєстрацію 
            // зберігати дані юзернейм,хеширований пароль,почта в базі даних
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            LoginWindow loginwindow = new();
            loginwindow.Show();
            this.Close();
        }
    }
}
