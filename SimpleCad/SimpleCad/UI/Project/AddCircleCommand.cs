using System;
using System.Windows.Input;
using System.Windows.Media;
using SimpleCad.UI.Geometry;

namespace SimpleCad.UI.Project
{
    internal class AddCircleCommand : ICommand
    {
        private readonly ProjectVm _vm;

        public AddCircleCommand(ProjectVm vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _vm.Geometry.Add(new CircleGeometryVm()
            {
                Thickness = 2,
                CenterX = 100,
                CenterY = 100,
                Color = Colors.Black,
                Diametr = 50
                
            });
        }

        public event EventHandler CanExecuteChanged;
    }
}
