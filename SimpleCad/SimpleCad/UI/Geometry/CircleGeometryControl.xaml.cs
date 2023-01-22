using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace SimpleCad.UI.Geometry
{
    /// <summary>
    /// Interaction logic for CircleGeometryControl.xaml
    /// </summary>
    public partial class CircleGeometryControl : UserControl
    {
        public CircleGeometryControl()
        {
            InitializeComponent();
        }

        private void TopPoint_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is PointGeometryControl topPoint)
            {
                topPoint.CaptureMouse();
            }
        }

        private void TopPoint_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is PointGeometryControl topPoint && topPoint.IsMouseCaptured)
            {
                topPoint.ReleaseMouseCapture();
            }
        }

        private void TopPoint_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is PointGeometryControl topPoint 
                && topPoint.IsMouseCaptured
                && DataContext is CircleGeometryVm circle)
            {
                var curMousePoint = e.GetPosition(CenterPoint);
                circle.Diametr = -2* curMousePoint.Y - CenterPoint.ActualHeight;
            }
        }

        private void Circle_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse ellipse && DataContext is CircleGeometryVm circle)
            {
                if(!circle.IsSelected)
                    circle.IsMouseOver = true;
            }
        }

        private void Circle_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse ellipse && DataContext is CircleGeometryVm circle)
            {
                circle.IsMouseOver = false;
            }
        }
    }
}
