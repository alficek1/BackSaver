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

namespace BackSaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void odebratButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void pridatButton_Click_1(object sender, RoutedEventArgs e)
        {
            //   HraWindow hraWindow = new(spravceHer);
            new PridatHru().ShowDialog();
        }
    }
}