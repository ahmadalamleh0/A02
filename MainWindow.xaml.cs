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
        private void OnAboutClicked(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        // TODO: Handle other menu items (New, Open, Save, SaveAs) 
        private void NewFile()
        {
            if (isModified)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    SaveFile();
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            WorkArea.Clear();
            currentFile = null;
            this.Title = "Untitled";
        }

        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                WorkArea.Text = File.ReadAllText(openFileDialog.FileName);
                currentFile = openFileDialog.FileName;
                this.Title = System.IO.Path.GetFileName(currentFile);
                isModified = false;
            }
        }
        private void SaveFile()
        {
            if (string.IsNullOrEmpty(currentFile))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, WorkArea.Text);
                    currentFile = saveFileDialog.FileName;
                    this.Title = System.IO.Path.GetFileName(currentFile);
                    isModified = false;
                }
            }
            else
            {
                File.WriteAllText(currentFile, WorkArea.Text);
                isModified = false;
            }
        }

        private void SaveAsFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, WorkArea.Text);
                currentFile = saveFileDialog.FileName;
                this.Title = System.IO.Path.GetFileName(currentFile);
                isModified = false;
            }
        }
        private void OnExitClicked(object sender, RoutedEventArgs e)
        {
            if (isModified)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes before exiting?", "Confirmation", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    SaveFile();
                    this.Close();
                }
                else if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }


        }
    }
}



    }
}
