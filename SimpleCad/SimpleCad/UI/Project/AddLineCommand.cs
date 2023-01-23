using System;
using System.Windows.Input;
using System.Windows.Media;
using SimpleCad.UI.Geometry;

namespace SimpleCad.UI.Project
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
            _vm.Geometry.Add(new LineGeometryVm()
            {
                StartPointX = 50,
                StartPointY = 50,
                EndPointX = 100,
                EndPointY = 100,
                Thickness = 2,
                Color = Colors.Black
            });
        }

        public event EventHandler CanExecuteChanged;
    }
}
