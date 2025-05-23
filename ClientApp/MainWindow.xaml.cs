using FoodDataBase.Entities;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ClientApp.CalorieCalculator;


namespace ClientApp
{

    public partial class MainWindow : Window
    {

        private ObservableCollection<FoodEntry> FoodList = new ObservableCollection<FoodEntry>();
        private double targetCalories;
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
            DataContext = this;

            FoodDataGrid.ItemsSource = context.Foods.ToList();
            FoodSelectionComboBox.ItemsSource = context.Foods.ToList();

            FoodList = new ObservableCollection<FoodEntry>(
                context.FoodEntries
                    .Include(f => f.Food)
                    .Where(f => f.UserId == UserId)
                    .ToList()
            );

            context = new CalorieAppDB();
            UserId = id;
            UserGmail = gmail;

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

            var activityLevel = (CalorieCalculator.ActivityLevel)(ActivityLevelComboBox.SelectedIndex + 1);

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
            targetCalories = calculator.Calculate();

            ResultTextBlock.Text = $"You need to eat {targetCalories:F0} kcal";
            UpdateCalorieSummary();
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

        private void AddNewFood_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FoodNameTextBox.Text))
            {
                MessageBox.Show("Please enter a food name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string name = FoodNameTextBox.Text.Trim();

            if (!int.TryParse(CaloriesTextBox.Text, out int calories) || calories <= 0)
            {
                MessageBox.Show("Please enter a valid number of calories (must be a positive integer).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(ProteinTextBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal protein) || protein < 0)
            {
                MessageBox.Show("Please enter a valid amount of protein (must be a non-negative number).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!decimal.TryParse(CarbsTextBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal carbs) || carbs < 0)
            {
                MessageBox.Show("Please enter a valid amount of carbohydrates (must be a non-negative number).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(FatsTextBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal fats) || fats < 0)
            {
                MessageBox.Show("Please enter a valid amount of fats (must be a non-negative number).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var existingFood = context.Foods.FirstOrDefault(f => f.Name != null && f.Name.ToLower() == name.ToLower());

            if (existingFood != null)
            {
                var result = MessageBox.Show(
                    $"Food with the name \"{name}\" already exists.\nDo you want to replace it?",
                    "Duplicate Food",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (result == MessageBoxResult.Yes)
                {
                    existingFood.CaloriesPer100g = calories;
                    existingFood.ProteinPer100g = protein;
                    existingFood.CarbsPer100g = carbs;
                    existingFood.FatsPer100g = fats;

                    context.SaveChanges();

                    MessageBox.Show("Food entry updated successfully.", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Operation cancelled.", "Cancelled", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                var newFood = new Food
                {
                    Name = name,
                    CaloriesPer100g = calories,
                    ProteinPer100g = protein,
                    CarbsPer100g = carbs,
                    FatsPer100g = fats
                };

                context.Foods.Add(newFood);
                context.SaveChanges();

                MessageBox.Show("New food added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // Clear input fields
            FoodNameTextBox.Text = "";
            CaloriesTextBox.Text = "";
            ProteinTextBox.Text = "";
            CarbsTextBox.Text = "";
            FatsTextBox.Text = "";
        
        }


        private void AddFoodEntry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ResultTextBlock.Text))
                {
                    MessageBox.Show("Please calculate your daily calorie target using the formula first.", "Missing Target", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                var foods = context.Foods.ToList();

                FoodSelectionComboBox.ItemsSource = foods;

                var selectedFood = FoodSelectionComboBox.SelectedItem as Food;
                if (selectedFood == null)
                {
                    MessageBox.Show("Please select a food item from the dropdown list");
                    return;
                }

                if (!double.TryParse(GramsInputTextBox.Text, out double grams) || grams <= 0)
                {
                    MessageBox.Show("Please enter a valid amount of grams");
                    return;
                }

                double entryCalories = (selectedFood.CaloriesPer100g * grams) / 100.0;

                var today = DateTime.Today;
                var todaysEntries = FoodList.Where(f => f.Date.Date == today);
                double currentTotalCalories = todaysEntries.Sum(f => (f.Food.CaloriesPer100g * f.Grams) / 100.0);

                

                if (currentTotalCalories + entryCalories > targetCalories)
                {
                    var result = MessageBox.Show(
                        "Adding this food will exceed your daily calorie target. Do you want to continue?",
                        "Calorie Warning",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    );

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }
                }

                var foodEntry = new FoodEntry
                {
                    FoodId = selectedFood.Id,
                    Food = selectedFood,
                    Grams = grams,
                    Date = DateTime.Now,
                    UserId = UserId,
                };

                context.FoodEntries.Add(foodEntry);
                FoodList.Add(foodEntry);
                context.SaveChanges();


                GramsInputTextBox.Text = "";
                FoodSelectionComboBox.SelectedItem = null;

                UpdateCalorieSummary();
                MessageBox.Show("Food entry added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateCalorieSummary()
        {
            try
            {
                var today = DateTime.Today;
                var todaysEntries = FoodList.Where(f => f.Date.Date == today);
                double totalCalories = todaysEntries.Sum(f => (f.Food.CaloriesPer100g * f.Grams) / 100.0);

                

                double progressPercentage = Math.Min((totalCalories / targetCalories) * 100, 100);
                CaloriesProgressBar.Value = progressPercentage;
                CaloriesProgressText.Text = $"{totalCalories:F0} / {targetCalories:F0} calories";

                if (totalCalories > targetCalories)
                {
                    CaloriesProgressBar.Foreground = new SolidColorBrush(Colors.Red);
                    var entriesToRemove = FoodList.Where(f => f.Date.Date == today).ToList();
                    foreach (var entry in entriesToRemove)
                    {
                        context.FoodEntries.Remove(entry);
                        FoodList.Remove(entry);
                    }
                    context.SaveChanges();
                    CaloriesProgressBar.Value = 0;
                    CaloriesProgressText.Text = $"0 / {targetCalories:F0} calories";
                }
                else if (progressPercentage > 90)
                {
                    CaloriesProgressBar.Foreground = new SolidColorBrush(Colors.Orange);
                }
                else
                {
                    CaloriesProgressBar.Foreground = new SolidColorBrush(Colors.Green);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating calorie summary: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



    //[AddINotifyPropertyChangedInterface]
    //public class FoodModel
    //{
    //    public string Name { get; set; }


        private void ClearTotal_Click(object sender, RoutedEventArgs e)
        {
            CaloriesProgressBar.Value = 0;
            CaloriesProgressBar.Foreground = new SolidColorBrush(Colors.Green);
        }


    }
}