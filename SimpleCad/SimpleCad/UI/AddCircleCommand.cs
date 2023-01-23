﻿using System;
using System.Windows.Input;
using SimpleCad.Models;
using SimpleCad.UI.Geometry;

namespace SimpleCad.UI
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
            var circle = new CircleGeometry()
            {
                Thickness = 2,
                Center = new PointGeometry(1, 3),
                Color = 1,
                Radius = 10,
            };
            _vm.Geometry.Add(new CircleGeometryVm(circle));
        }

        public event EventHandler CanExecuteChanged;
    }
}
