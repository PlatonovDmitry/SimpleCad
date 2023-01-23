using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace SimpleCad.UI.Geometry
{
    /// <summary>
    /// Interaction logic for LineGeometryControl.xaml
    /// </summary>
    public partial class LineGeometryControl : UserControl
    {
        public LineGeometryControl()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Line line && DataContext is LineGeometryVm vm)
            {
                if (!vm.IsSelected)
                    vm.IsMouseOver = true;
            }
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Line line && DataContext is LineGeometryVm vm)
            {
                vm.IsMouseOver = false;
            }
        }
    }
}
