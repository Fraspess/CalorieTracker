using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp
{
   
    public partial class MainWindow : Window
    {
        int UserId;
        string UserGmail;
        public MainWindow(int id,string gmail)
        {
            InitializeComponent();
            UserId = id;
            UserGmail = gmail;
            MessageBox.Show($"Gmail : {gmail}\nId : {id}");
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimize_Button(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximized_Button(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
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

            var calculator = new CalorieCalculator(gender, weight, height, age, goal);
            double result = calculator.Calculate();

            ResultTextBlock.Text = $"you need to eat {result:F0} kkal";
                     
        }

    }
}