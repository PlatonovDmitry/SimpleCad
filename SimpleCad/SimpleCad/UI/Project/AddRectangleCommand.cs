using System;
using System.Windows.Input;
using System.Windows.Media;
using SimpleCad.UI.Geometry;

namespace SimpleCad.UI.Project
{
    internal class AddRectangleCommand : ICommand
    {
        private readonly ProjectVm _vm;

        public AddRectangleCommand(ProjectVm vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _vm.Geometry.Add(new RectangleGeometryVm()
            {
                LeftTopX = 50,
                RightBottomX = 150,
                LeftTopY = 50,
                RightBottomY = 150,
                Color = Colors.Black,
                Thickness = 2
            });
        }

        public event EventHandler CanExecuteChanged;
    }
}
