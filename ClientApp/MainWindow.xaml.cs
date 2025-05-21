using PropertyChanged;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
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
using static ClientApp.CalorieCalculator;


namespace ClientApp
{

    public partial class MainWindow : Window
    {


        public string UserGmail { get; set; }
        //FoodInfo model;
        int UserId;
        CalorieAppDB context;

        public MainWindow(int id, string gmail)
        {
            InitializeComponent();
            context = new CalorieAppDB();
            UserId = id;
            UserGmail = gmail;
            //MessageBox.Show($"Gmail : {gmail}\nId : {id}");

            DataContext = this;

            FoodDataGrid.ItemsSource = context.Foods.ToList();

            //this.DataContext = model;
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
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
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

        private void FindFood_TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(FindFoodTextBox.Text) || FindFoodTextBox.Text == "Find food...")
            {
                return;
            }         

            if (context != null)
            {
                string name = FindFoodTextBox.Text;
                var products = context.Foods.ToList().Where(x => x.Name.ToLower().Contains(name.ToLower()));

                //var products = context.Foods.ToList();

                FoodDataGrid.ItemsSource = products;
            }

        }

        private void FindFoodTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FindFoodTextBox.Text))
            {
                FindFoodTextBox.Text = "Find food...";
                FindFoodTextBox.Foreground = Brushes.Gray; 
            }
        }

        private void FindFoodTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FindFoodTextBox.Text == "Find food...")
            {
                FindFoodTextBox.Text = "";
                FindFoodTextBox.Foreground = Brushes.Black;
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfilePopup.IsOpen = true;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

    }

    //[AddINotifyPropertyChangedInterface]
    //public class FoodInfo
    //{
    //    public ObservableCollection<FoodModel> foods { get; set; }

    //    public FoodInfo(string Name,string CaloriesPer100g)
    //    {
    //        foods = new();
    //        foods.Add(new FoodModel { Name = Name, CaloriesPer100g = int.Parse(CaloriesPer100g) });
    //    }
    //}

    //[AddINotifyPropertyChangedInterface]

    //public class FoodModel
    //{
    //    public string Name { get; set; }

    //    public int CaloriesPer100g { get; set; }
    //}
}