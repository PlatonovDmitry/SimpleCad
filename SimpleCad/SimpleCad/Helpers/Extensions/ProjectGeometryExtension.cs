using System;
using System.Windows.Media;
using SimpleCad.Models;
using SimpleCad.UI.Geometry;
using LineGeometry = SimpleCad.Models.LineGeometry;
using RectangleGeometry = SimpleCad.Models.RectangleGeometry;

namespace SimpleCad.Helpers.Extensions
{
    internal static class ProjectGeometryExtension
    {
        public static ProjectGeometryVm GetGeometryVm(this ProjectGeometry geometry)
        {
            switch (geometry)
            {
                case LineGeometry line:
                    return line.GetLineGeometryVm();
                case CircleGeometry circle:
                    return circle.GetCircleGeometryVm();
                case RectangleGeometry rectangle:
                    return rectangle.GetRectangleGeometryVm();

            }

            throw new ArgumentException("Не известный тип геометрии");
        }

        public static ProjectGeometry SaveGeometry(this ProjectGeometryVm vm)
        {
            switch (vm)
            {
                case LineGeometryVm line:
                    return line.SaveLineGeometry();
                case CircleGeometryVm circle:
                    return circle.SaveCircleGeometry();
                case RectangleGeometryVm rectangle:
                    return rectangle.SaveRectangleGeometry();

            }

            throw new ArgumentException("Не известный тип геометрии");
        }

        public static void LoadVm(this ProjectGeometryVm vm, ProjectGeometry geometry)
        {
            var arrBytes = BitConverter.GetBytes(geometry.Color);
            // Распределение байт
            //byte a = arrBytes[3];
            var r = arrBytes[0];
            var g = arrBytes[1];
            var b = arrBytes[2];

            vm.Color = Color.FromRgb(r, g, b);
            vm.Thickness = geometry.Thickness;
        }

        public static void SaveVm(this ProjectGeometryVm vm, ProjectGeometry geometry)
        {
            var bytes = new[] { vm.Color.R, vm.Color.G, vm.Color.B, vm.Color.A };
            geometry.Color = BitConverter.ToInt32(bytes, 0);
            geometry.Thickness = vm.Thickness;
        }

    }
}
