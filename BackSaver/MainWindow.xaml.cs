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
        private readonly SpravceHer spravceHer = new();
        public MainWindow()
        {
            
            InitializeComponent();
            try
            {
                spravceHer.Nacti();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DataContext = spravceHer;
        }

        private void odebratButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (hryListBox.SelectedItem != null)
            {
                try
                {
                    spravceHer.Odeber((Hra)hryListBox.SelectedItem);
                    spravceHer.Uloz();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void pridatButton_Click_1(object sender, RoutedEventArgs e)
        {
            //   HraWindow hraWindow = new(spravceHer);
            new PridatHru(spravceHer).ShowDialog();
        }


    }
}