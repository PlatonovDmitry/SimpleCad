using System;
using System.Windows.Input;
using SimpleCad.Models;
using SimpleCad.UI.Geometry;

namespace SimpleCad.UI
{
    internal class AddRectangleCommand : ICommand
    {
        private ProjectVm _vm;

        public AddRectangleCommand(ProjectVm vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var circle = new RectangleGeometry()
            {
                LeftTop = new PointGeometry(-50, 50),
                RightBottom = new PointGeometry(50, -50),
                Thickness = 2,
                Color = 1,
            };
            _vm.Geometry.Add(new RectangleGeometryVm(circle));
        }

        public event EventHandler CanExecuteChanged;
    }
}
