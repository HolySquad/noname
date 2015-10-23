using System.Windows;

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
    }
}