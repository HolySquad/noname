using System.Windows;
using Repository;

namespace ServerGUI
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PathTxt.Foreground = SystemColors.GrayTextBrush;
        }

        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            ScanFiles();
        }

        private void ScanFiles()
        {
           FileScanner.ScanFolder(PathTxt.Text);
        }
    }
}