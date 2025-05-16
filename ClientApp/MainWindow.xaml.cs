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
        public MainWindow(int id)
        {
            InitializeComponent();
            UserId = id;
            MessageBox.Show(UserId.ToString());
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

            double weight = double.Parse(WeightTextBox.Text);
            double height = double.Parse(HeightTextBox.Text);
            int age = int.Parse(AgeTextBox.Text);

            var calculator = new CalorieCalculator(gender, weight, height, age, goal);
            double result = calculator.Calculate();

            ResultTextBlock.Text = $"you need {result:F0} kkal";


        }

    }
}