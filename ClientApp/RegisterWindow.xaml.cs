using FoodDataBase;
using FoodDataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        CalorieAppDB context;
        public RegisterWindow()
        {
            InitializeComponent();
            context = new CalorieAppDB();
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
            string email = EmailTextBox.Text.Trim();
            string password = PasswordTextBox.Password;
            string confirmPassword = ConfirmPasswordTextBox.Password;
            if(!ValidateInput(email,password,confirmPassword))
            {
                return;
            }

            try
            {
                var user = context.Users.FirstOrDefault(u => u.Gmail == email);
                if(user != null)
                {
                    MessageBox.Show("This gmail is alredy taken","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                }

                // хешуємо пароль и записуємо в базу даних нового користувача
                var hashPassword = PasswordHasher.HashPassword(password);
                context.Users.Add(new User
                {
                    Gmail = email,
                    PasswordHash = hashPassword 
                });
                context.SaveChanges();
                MessageBox.Show("Successfully registered!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginWindow loginWindow = new();
                loginWindow.Show();
                this.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }





        }

        private bool ValidateInput(string email, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Invalid gmail format", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        // старий варіант з кнопкою
        //private void Login_Button(object sender, RoutedEventArgs e)
        //{
        //    LoginWindow loginwindow = new();
        //    loginwindow.Show();
        //    this.Close();
        //}

        private void LoginNow_TextBlock_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoginWindow loginwindow = new();
            loginwindow.Show();
            this.Close();
        }
    }
}
