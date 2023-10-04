using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;

namespace A02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFile = null;
        private bool isModified = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnWorkAreaTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Update character count
            CharacterCount.Text = $"{WorkArea.Text.Length} characters";
            isModified = true;
        }

        private void OnNewClicked(object sender, RoutedEventArgs e)
        {
            NewFile();
        }
        private void OnSaveClicked(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }
        private void OnSaveAsClicked(object sender, RoutedEventArgs e)
        {
            SaveAsFile();
        }
        private void OnOpenClicked(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }
    }
}
