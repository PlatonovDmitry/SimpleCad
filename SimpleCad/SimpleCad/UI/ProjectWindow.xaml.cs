using System.Windows;

namespace SimpleCad.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class ProjectWindow : Window
    {
        internal ProjectWindow(ProjectVm vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
