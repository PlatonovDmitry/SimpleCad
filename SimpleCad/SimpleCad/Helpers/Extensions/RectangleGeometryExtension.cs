using SimpleCad.Models;
using SimpleCad.UI.Geometry;

namespace SimpleCad.Helpers.Extensions
{
    internal static class RectangleGeometryExtension
    {
        public static RectangleGeometryVm GetRectangleGeometryVm(this RectangleGeometry rectangle)
        {
            var rectangleGeometry = new RectangleGeometryVm();

            rectangleGeometry.LoadVm(rectangle);

            rectangleGeometry.LeftTopX = rectangle.LeftTop.X;
            rectangleGeometry.LeftTopY = rectangle.LeftTop.Y;
            rectangleGeometry.RightBottomX = rectangle.RightBottom.X;
            rectangleGeometry.RightBottomY = rectangle.RightBottom.Y;

            return rectangleGeometry;
        }

        public static RectangleGeometry SaveRectangleGeometry(this RectangleGeometryVm vm)
        {
            var rectangle = new RectangleGeometry();

            vm.SaveVm(rectangle);

            rectangle.LeftTop = new PointGeometry(vm.LeftTopX, vm.LeftTopY);
            rectangle.RightBottom = new PointGeometry(vm.RightBottomX, vm.RightBottomY);

            return rectangle;
        }
    }
}
