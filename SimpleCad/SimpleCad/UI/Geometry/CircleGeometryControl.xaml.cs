using System;
using System.Windows;
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

        private void SetCursor(Ellipse ellipse, MouseEventArgs e)
        {
            var curMousePoint = e.GetPosition(CenterPoint);
            var delta = ellipse.ActualHeight * Math.Sin(Math.PI / 12) / 2;
            if (Math.Sign(curMousePoint.Y) * curMousePoint.Y < delta)
            {
                ellipse.Cursor = Cursors.SizeWE;
            }
            else if (Math.Sign(curMousePoint.X) * curMousePoint.X < delta)
            {
                ellipse.Cursor = Cursors.SizeNS;
            }
            else
            {
                ellipse.Cursor = Math.Sign(curMousePoint.X) == Math.Sign(curMousePoint.Y)
                    ? Cursors.SizeNWSE
                    : Cursors.SizeNESW;
            }
        }

        private void Circle_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse ellipse && DataContext is CircleGeometryVm vm)
            {
                if(!vm.IsSelected)
                    vm.IsMouseOver = true;

                SetCursor(ellipse, e);
            }
        }

        private void Circle_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse ellipse && DataContext is CircleGeometryVm vm)
            {
                vm.IsMouseOver = false;
                ellipse.Cursor = Cursors.Arrow;
            }
        }

        private void Circle_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Ellipse ellipse)
            {
                ellipse.CaptureMouse();
            }
        }

        private void Circle_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Ellipse ellipse)
            {
                ellipse.ReleaseMouseCapture();
            }
        }

        private void Circle_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse ellipse
                && DataContext is CircleGeometryVm vm)
            {
                if(vm.IsMouseOver)
                    SetCursor(ellipse, e);

                if(ellipse.IsMouseCaptured)
                {
                    var curMousePoint = e.GetPosition(CenterPoint);
                    var curX = curMousePoint.X - CenterPoint.ActualWidth;
                    var curY = curMousePoint.Y - CenterPoint.ActualHeight;
                    vm.Diametr = 2 * Math.Sqrt(Math.Pow(curX, 2) + Math.Pow(curY, 2));
                }
            }
        }
    }
}
