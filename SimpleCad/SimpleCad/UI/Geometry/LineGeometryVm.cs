using SimpleCad.Models;

namespace SimpleCad.UI.Geometry
{
    internal class LineGeometryVm : ProjectGeometryVm
    {
        private PointGeometry _startPoint;
        private PointGeometry _endPoint;

        public LineGeometryVm(LineGeometry geometry) : base(geometry)
        {
            StartPoint = geometry.StartPoint;
            EndPoint = geometry.EndPoint;
        }

        public PointGeometry StartPoint
        {
            get => _startPoint;
            set
            {
                _startPoint = value;
                OnPropertyChanged(nameof(StartPoint));
            }
        }

        public PointGeometry EndPoint
        {
            get => _endPoint;
            set
            {
                _endPoint = value;
                OnPropertyChanged(nameof(EndPoint));
            }
        }
    }
}
