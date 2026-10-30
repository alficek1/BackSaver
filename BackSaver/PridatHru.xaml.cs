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
using System.Windows.Forms;
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
                System.Windows.MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void exeSouborButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Title = "Vyberte spustitelný soubor";
            fileDialog.Filter = "Spustitelné soubory (*.exe)|*.exe|Všechny soubory (*.*)|*.*";
            if (fileDialog.ShowDialog() == true)
            {
                /* cesta a samostatný název souboru
                string path = fileDialog.FileName;
                string fileName = fileDialog.SafeFileName;*/
                exeSouborTextBox.Text = fileDialog.FileName;
            }
            else
            {
                exeSouborTextBox.Text = "";
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
          
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                saveTextBox.Text = dialog.SelectedPath;
            }
            else
            {
                saveTextBox.Text = "";
            }
        }

        private void zalohaButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                zalohaTextBox.Text = dialog.SelectedPath;
            }
            else
            {
                zalohaTextBox.Text = "";
            }
        }
    }
}
