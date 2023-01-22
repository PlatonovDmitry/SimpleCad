using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace SimpleCad.UI.Geometry
{
    /// <summary>
    /// Interaction logic for GeometryPointControl.xaml
    /// </summary>
    public partial class PointGeometryControl : UserControl
    {
        public PointGeometryControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CoordinateXProperty = DependencyProperty.Register(
            "CoordinateX", typeof(double), typeof(PointGeometryControl), new PropertyMetadata(default(double)));

        public double CoordinateX
        {
            get { return (double)GetValue(CoordinateXProperty); }
            set { SetValue(CoordinateXProperty, value); }
        }

        public static readonly DependencyProperty CoordinateYProperty = DependencyProperty.Register(
            "CoordinateY", typeof(double), typeof(PointGeometryControl), new PropertyMetadata(default(double)));

        public double CoordinateY
        {
            get { return (double)GetValue(CoordinateYProperty); }
            set { SetValue(CoordinateYProperty, value); }
        }

        public static readonly DependencyProperty EditCursorProperty = DependencyProperty.Register(
            "EditCursor", typeof(Cursor), typeof(PointGeometryControl), new PropertyMetadata(default(Cursor)));

        public Cursor EditCursor
        {
            get { return (Cursor)GetValue(EditCursorProperty); }
            set { SetValue(EditCursorProperty, value); }
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Rectangle rectangle)
            {
                rectangle.StrokeThickness = 2;
                rectangle.Cursor = EditCursor;
            }
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Rectangle rectangle)
            {
                rectangle.StrokeThickness = 0;
                rectangle.Cursor = Cursors.Arrow;
            }
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is UIElement point)
            {
                point.CaptureMouse();
            }
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is UIElement point)
            {
                point.ReleaseMouseCapture();
            }
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is UIElement point && point.IsMouseCaptured)
            {
                var curMousePoint = e.GetPosition(point);
                CoordinateX += curMousePoint.X;
                CoordinateY -= curMousePoint.Y;
            }
        }
    }
}
