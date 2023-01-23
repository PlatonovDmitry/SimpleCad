using SimpleCad.Models;
using SimpleCad.UI.Geometry;

namespace SimpleCad.Helpers.Extensions
{
    internal static class CircleGeometryExtension
    {
        public static CircleGeometryVm GetCircleGeometryVm(this CircleGeometry circle)
        {
            var circleGeometry = new CircleGeometryVm();

            circleGeometry.LoadVm(circle);

            circleGeometry.Diametr = 2 *circle.Radius;
            circleGeometry.CenterX = circle.Center.X;
            circleGeometry.CenterY = circle.Center.Y;
            
            return circleGeometry;
        }

        public static CircleGeometry SaveCircleGeometry(this CircleGeometryVm vm)
        {
            var circle = new CircleGeometry();

            vm.SaveVm(circle);

            circle.Radius = vm.Diametr/2;
            circle.Center = new PointGeometry(vm.CenterX, vm.CenterY);
            
            return circle;
        }
    }
}
