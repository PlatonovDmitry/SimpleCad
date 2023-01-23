using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SimpleCad.Helpers;

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