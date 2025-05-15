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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // айди юзера передаем як аргуемент mainwindow
        int UserId;
        public MainWindow(int id)
        {
            InitializeComponent();
            UserId = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}