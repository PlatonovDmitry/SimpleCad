using SimpleCad.Models;

namespace SimpleCad.UI
{
    internal class RectangleGeometryVm : ProjectGeometryVm
    {
        private PointGeometry _leftBottom;
        private PointGeometry _rightTop;

        public RectangleGeometryVm(RectangleGeometry geometry) : base(geometry)
        {
            LeftBottom = geometry.LeftBottom;
            RightTop = geometry.RightTop;
        }

        public PointGeometry LeftBottom
        {
            get => _leftBottom;
            set
            {
                _leftBottom = value;
                OnPropertyChanged(nameof(LeftBottom));
            }
        }

        public PointGeometry RightTop
        {
            get => _rightTop;
            set
            {
                _rightTop = value;
                OnPropertyChanged(nameof(RightTop));
            }
        }
    }
}
