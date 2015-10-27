using System;
using System.Windows;
using System.Windows.Forms;
using Repository.Interfaces;
using MessageBox = System.Windows.MessageBox;

namespace ServerGUI
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            PathTxt.Foreground = SystemColors.GrayTextBrush;
            ScanBtn.IsEnabled = false;
        }

        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            Instance = this;
            ScanBtn.IsEnabled = true;
            ScanFiles();
        }

        private void ScanFiles()
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result.Equals(System.Windows.Forms.DialogResult.OK))
            {
                PathTxt.Text = dialog.SelectedPath;
            }
        }

        private void ScanClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PathTxt.Text != "Your Path here")
                {
                    
                    FileScanner.ScanFolder(PathTxt.Text);
                }
                else MessageBox.Show("Choose a folder!");
            }
            catch (Exception ex)
            {
                //TODO add some Logger (ex log4net) or something else
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}