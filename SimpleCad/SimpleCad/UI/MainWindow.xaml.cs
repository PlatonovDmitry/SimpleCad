using System.Windows;

namespace SimpleCad.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : Window
    {
        internal MainWindow(MainVm vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
