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

        private Point _startMousePoint;

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            var curMousePoint = e.GetPosition(Root);
            if (sender is UIElement caughtElement && caughtElement.IsMouseCaptured)
            {
                var contentPresenter = caughtElement.ParentOfType<ContentPresenter>();

                var left = Canvas.GetLeft(contentPresenter);
                var top = Canvas.GetTop(contentPresenter);
                Canvas.SetLeft(contentPresenter, left + curMousePoint.X - _startMousePoint.X);
                Canvas.SetTop(contentPresenter, top + curMousePoint.Y - _startMousePoint.Y);
            }

            _startMousePoint = curMousePoint;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle && sender is UIElement caughtElement)
            {
                caughtElement.CaptureMouse();
            }
        }

        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle 
                && sender is UIElement caughtElement 
                && caughtElement.IsMouseCaptured)
            {
                caughtElement.ReleaseMouseCapture();
            }
        }
    }
}