using System;
using System.Windows.Input;
using SimpleCad.Models;
using SimpleCad.UI.Geometry;

namespace SimpleCad.UI
{
    internal class AddLineCommand : ICommand
    {
        private readonly ProjectVm _vm;

        public AddLineCommand(ProjectVm vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var circle = new LineGeometry()
            {
                StartPoint = new PointGeometry(-50, 50),
                EndPoint = new PointGeometry(50, -50),
                Thickness = 2,
                Color = 1,
            };
            _vm.Geometry.Add(new LineGeometryVm(circle));
        }

        public event EventHandler CanExecuteChanged;
    }
}
