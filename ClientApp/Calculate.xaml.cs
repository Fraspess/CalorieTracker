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
using static ClientApp.CalorieCalculator;

namespace ClientApp
{
    /// <summary>
    /// Логика взаимодействия для Calculate.xaml
    /// </summary>
    public partial class Calculate : Window
    {
        public Calculate()
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
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var gender = (GenderComboBox.SelectedIndex == 0)
            ? CalorieCalculator.Gender.Male
            : CalorieCalculator.Gender.Female;

            var goal = (GoalComboBox.SelectedIndex == 0)
                ? CalorieCalculator.Goal.LoseWeight
                : CalorieCalculator.Goal.GainWeight;

            var activityLevel = (ActivityLevel)(ActivityLevelComboBox.SelectedIndex + 1);

            bool isWeightValid = double.TryParse(WeightTextBox.Text, out double weight);
            bool isHeightValid = double.TryParse(HeightTextBox.Text, out double height);
            bool isAgeValid = int.TryParse(AgeTextBox.Text, out int age);

            if (!isWeightValid || !isHeightValid || !isAgeValid)
            {
                MessageBox.Show("Please enter valid numeric values for weight, height, and age.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (weight <= 0 || height <= 0 || age <= 0)
            {
                MessageBox.Show("Values must be greater than zero.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var calculator = new CalorieCalculator(gender, weight, height, age, goal, activityLevel);
            double result = calculator.Calculate();

            ResultTextBlock.Text = $"You need to eat {result:F0} kcal";

        }
    }
}
