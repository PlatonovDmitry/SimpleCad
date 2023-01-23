using System.Windows.Controls;
using System.Windows.Input;
using SimpleCad.UI.Geometry;
using SimpleCad.UI.Project;

namespace SimpleCad.UI
{
    /// <summary>
    /// Interaction logic for CanvasControl.xaml
    /// </summary>
    public partial class CanvasControl : UserControl
    {
        public CanvasControl()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ContentControl control
                && control.Content is ProjectGeometryVm vm
                && DataContext is ProjectVm project)
            {
                project.SelectedGeometry = vm;
            }
        }
    }
}
