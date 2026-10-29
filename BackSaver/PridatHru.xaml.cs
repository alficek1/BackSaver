using Microsoft.Win32;
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
    /// <summary>
    /// Interakční logika pro PridatHru.xaml
    /// </summary>
    public partial class PridatHru : Window
    {
        private readonly SpravceHer spravceHer;

        public PridatHru(SpravceHer spravceHer)
        {
            InitializeComponent();
            this.spravceHer = spravceHer;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                spravceHer.Pridej(hraTextBox.Text, exeSouborTextBox.Text, saveTextBox.Text, zalohaTextBox.Text);
                spravceHer.Uloz();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void exeSouborButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                exeSouborTextBox.Text = fileDialog.FileName;
                
            }
            else
            {
                exeSouborTextBox.Text = "";
            }
        }
    }
}
