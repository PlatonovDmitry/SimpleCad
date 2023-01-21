using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleCad.Models;
using SimpleCad.UI.Geometry;

namespace SimpleCad.UI
{
    internal class AddCircleCommand : ICommand
    {
        private ProjectVm _vm;

        public AddCircleCommand(ProjectVm vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var circle = new CircleGeometry()
            {
                Width = 2,
                Center = new PointGeometry(1, 3),
                Color = 1,
                Radius = 10,
            };
            _vm.Geometry.Add(new CircleGeometryVm(circle));
        }

        public event EventHandler CanExecuteChanged;
    }
}
