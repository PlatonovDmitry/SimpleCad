using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using SimpleCad.Helpers.Enums;

namespace SimpleCad.UI.Geometry
{
    /// <summary>
    /// Interaction logic for RectangleGeometryControl.xaml
    /// </summary>
    public partial class RectangleGeometryControl : UserControl
    {
        private RectangleSide _resizingSide;

        public RectangleGeometryControl()
        {
            InitializeComponent();
        }

        private RectangleSide GetSide(MouseEventArgs e)
        {
            var curMouseLeftTopPoint = e.GetPosition(LeftTopPoint);
            var curMouseRightBottomPoint = e.GetPosition(RightBottomPoint);

            curMouseLeftTopPoint.X *= Math.Sign(curMouseLeftTopPoint.X);
            curMouseLeftTopPoint.Y *= Math.Sign(curMouseLeftTopPoint.Y);
            curMouseRightBottomPoint.X *= Math.Sign(curMouseRightBottomPoint.X);
            curMouseRightBottomPoint.Y *= Math.Sign(curMouseRightBottomPoint.Y);

            var side = RectangleSide.All;

            if (curMouseLeftTopPoint.X > LeftTopPoint.ActualWidth)
                side ^= RectangleSide.Left;

            if (curMouseLeftTopPoint.Y > LeftTopPoint.ActualHeight)
                side ^= RectangleSide.Top;

            if (curMouseRightBottomPoint.X > RightBottomPoint.ActualWidth)
                side ^= RectangleSide.Right;

            if (curMouseRightBottomPoint.Y > RightBottomPoint.ActualHeight)
                side ^= RectangleSide.Bottom;

            return side;
        }

        private void SetCursor(RectangleSide side, Rectangle rectangle)
        {
            switch (side)
            {
                case RectangleSide.Top:
                case RectangleSide.Bottom:
                    rectangle.Cursor = Cursors.SizeNS;
                    break;
                default:
                    rectangle.Cursor = Cursors.SizeWE;
                    break;
            }
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Rectangle rectangle && DataContext is RectangleGeometryVm vm)
            {
                if (!vm.IsSelected)
                    vm.IsMouseOver = true;

                var side = GetSide(e);
                SetCursor(side, rectangle);
            }
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Rectangle rectangle && DataContext is RectangleGeometryVm vm)
            {
                vm.IsMouseOver = false;
                rectangle.Cursor = Cursors.Arrow;
            }
        }

        

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rectangle)
            {
                rectangle.CaptureMouse();
                _resizingSide = GetSide(e);
            }
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rectangle)
            {
                rectangle.ReleaseMouseCapture();
            }
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Rectangle rectangle && rectangle.IsMouseCaptured)
            {
                switch (_resizingSide)
                {
                    case RectangleSide.Left:
                        var dLeft = e.GetPosition(LeftTopPoint).X;
                        LeftTopPoint.CoordinateX += dLeft;
                        break;
                    case RectangleSide.Top:
                        var dTop = e.GetPosition(LeftTopPoint).Y;
                        LeftTopPoint.CoordinateY -= dTop;
                        break;
                    case RectangleSide.Right:
                        var dRight = e.GetPosition(RightBottomPoint).X;
                        RightBottomPoint.CoordinateX += dRight;
                        break;
                    case RectangleSide.Bottom:
                        var dBottom = e.GetPosition(RightBottomPoint).Y;
                        RightBottomPoint.CoordinateY -= dBottom;
                        break;
                }
            }
        }
    }
}