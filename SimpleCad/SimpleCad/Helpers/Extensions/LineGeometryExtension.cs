using System;
using SimpleCad.Models;
using SimpleCad.UI.Geometry;

namespace SimpleCad.Helpers.Extensions
{
    internal static class LineGeometryExtension
    {
        public static LineGeometryVm GetLineGeometryVm(this LineGeometry line)
        {
            var lineGeometry = new LineGeometryVm();

            lineGeometry.LoadVm(line);

            lineGeometry.StartPointX = line.StartPoint.X;
            lineGeometry.EndPointX = line.EndPoint.X;
            lineGeometry.StartPointY = line.StartPoint.Y;
            lineGeometry.EndPointY = line.EndPoint.Y;
            
            return lineGeometry;
        }

        public static LineGeometry SaveLineGeometry(this LineGeometryVm vm)
        {
            var line = new LineGeometry();

            vm.SaveVm(line);

            line.EndPoint = new PointGeometry(vm.EndPointX + vm.PositionLeft, vm.EndPointY + vm.PositionTop);
            line.StartPoint = new PointGeometry(vm.StartPointX + vm.PositionLeft, vm.StartPointY + vm.PositionTop);

            return line;
        }
    }
}
