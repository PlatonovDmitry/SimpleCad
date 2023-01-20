using SimpleCad.Models;

namespace SimpleCad.UI
{
    internal class CircleGeometryVm : ProjectGeometryVm
    {
        private double _radius;
        private PointGeometry _center;

        public CircleGeometryVm(CircleGeometry geometry) : base(geometry)
        {
            Radius = geometry.Radius;
            Center = geometry.Center;
        }

        public PointGeometry Center
        {
            get => _center;
            set
            {
                _center = value;
                OnPropertyChanged(nameof(Center));
            }
        }

        public double Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }
    }
}
