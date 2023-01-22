namespace SimpleCad.Models
{
    internal class RectangleGeometry : ProjectGeometry
    {
        public PointGeometry LeftTop { get; set; }
        public PointGeometry RightBottom { get; set; }
    }
}
