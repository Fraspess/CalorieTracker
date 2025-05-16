using FoodDataBase;
using FoodDataBase.Entities;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        CalorieAppDB context;
        public LoginWindow()
        {
            InitializeComponent();
            context = new CalorieAppDB();
            var users = context.Users.ToList();
            

            //foreach(var user in users)
            //{
            //    MessageBox.Show(user.Gmail);
            //}
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

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            //тут зрівнюєм з логином і хешириваним паролем з бази даних і після відкриваєм окно mainwindow
            
            var accounts = context.Users.ToList();
            var user = context.Users.FirstOrDefault(u => u.Gmail == EmailTextBox.Text);
            if (user != null)
            {
                int id = user.Id;
                string password = PasswordTextBox.Password;

                //MessageBox.Show(user.PasswordHash);
                if (PasswordHasher.VerifyPassword(password,user.PasswordHash))
                {
                    // пишем що логін успішний і закриваєм це вікно і відкриваєм mainwindow
                    MessageBox.Show("Login successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new(id);
                    mainWindow.Show();
                    this.Close();
                }
            }
        }


        // старий варіант з кнопкою
        //private void Register_Button(object sender, RoutedEventArgs e)
        //{
        //    RegisterWindow registerWindow = new();
        //    registerWindow.Show();
        //    this.Close();
        //}

        private void ThemeButton_IsChecked(object sender, RoutedEventArgs e)
        {
            if (LightRadioButton.IsChecked == true)
            {
                Background = new SolidColorBrush(Colors.White);
                Foreground = new SolidColorBrush(Colors.Black);
            }

        }

        private void RegisterNow_TextBlock_Clicked(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();
            this.Close();   
        }
    }
}
