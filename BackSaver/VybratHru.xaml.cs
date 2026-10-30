using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BackSaver
{

    public partial class VybratHru : Window
    {
        private readonly SpravceHer spravceHer = new();
        public VybratHru()
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

        private void pridatButton_Click_1(object sender, RoutedEventArgs e)
        {
            new PridatHru(spravceHer).ShowDialog();
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

        private void aktualBt_Click_1(object sender, RoutedEventArgs e)
        {
            spravceHer.AktualHra = (Hra)hryListBox.SelectedItem;
            spravceHer.Uloz();
        }

        private void hryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            try
            {
                spravceHer.Uloz();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
