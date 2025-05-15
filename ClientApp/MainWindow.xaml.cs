using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace FavoritesClient
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string food = FoodInput.Text;
            if (!string.IsNullOrWhiteSpace(food))
            {
                SendRequest("ADD:" + food);
                FoodInput.Clear();
            }
        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            string result = SendRequest("GET");
            FavoritesList.Items.Clear();
            foreach (string item in result.Split(',', StringSplitOptions.RemoveEmptyEntries))
                FavoritesList.Items.Add(item.Trim());
        }

        private string SendRequest(string message)
        {
            try
            {
                using TcpClient client = new TcpClient("127.0.0.1", 5000);
                NetworkStream stream = client.GetStream();

                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int read = stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, read);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return "";
            }
        }
    }
}
