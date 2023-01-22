using SimpleCad.Helpers;
using SimpleCad.Models;

namespace SimpleCad.UI.Geometry
{
    internal class CircleGeometryVm : ProjectGeometryVm
    {
        private double _diametr;
        private double _centerX;
        private double _centerY;
        
        public CircleGeometryVm(CircleGeometry geometry) : base(geometry)
        {
            Diametr = 2 * geometry.Radius;
            CenterX = geometry.Center.X;
            CenterY = -geometry.Center.Y;
        }

        public override double PositionLeft => Constants.FIELD_CENTER_X + _centerX - _diametr/2;

        public override double PositionTop => Constants.FIELD_CENTER_Y + _centerY - _diametr / 2;

        public double CenterX
        {
            get => _centerX;
            set
            {
                Set(ref _centerX, value);
                OnPropertyChanged(nameof(PositionLeft));
            }
        }

        public double CenterY
        {
            get => _centerY;
            set
            {
                Set(ref _centerY, value);
                OnPropertyChanged(nameof(PositionTop));
            }
        }

        public double Diametr
        {
            get => _diametr;
            set
            {
                Set(ref _diametr, value);
                OnPropertyChanged(nameof(PositionLeft));
                OnPropertyChanged(nameof(PositionTop));
            }
        }
    }
}
