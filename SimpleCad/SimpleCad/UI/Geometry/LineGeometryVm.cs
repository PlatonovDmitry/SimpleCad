using System.Linq;
using System.Windows;
using SimpleCad.Helpers;
using SimpleCad.Models;

namespace SimpleCad.UI.Geometry
{
    internal class LineGeometryVm : ProjectGeometryVm
    {
        
        private double[] _y;
        private double[] _x;

        public LineGeometryVm(LineGeometry geometry) : base(geometry)
        {
            _x = new[] { Constants.FIELD_CENTER_X + geometry.StartPoint.X, Constants.FIELD_CENTER_X + geometry.EndPoint.X };
            _y = new[] { Constants.FIELD_CENTER_Y - geometry.StartPoint.Y, Constants.FIELD_CENTER_Y - geometry.EndPoint.Y };
        }

        public override double PositionLeft => _x.Min();
        public override double PositionTop => _y.Min();

        public double StartPointX
        {
            get => _x[0] - _x.Min();
            set
            {
                _x[0] = value + _x.Min();
                _riseXNotifiers();
            }
        }

        public double EndPointX
        {
            get => _x[1] - _x.Min();
            set
            {
                _x[1] = value + _x.Min();
                _riseXNotifiers();
            }
        }

        public double StartPointY
        {
            get => _y[0]-_y.Min();
            set
            {
                _y[0] = value + _y.Min();
                _riseYNotifiers();
            }
        }

        public double EndPointY
        {
            get => _y[1] - _y.Min();
            set
            {
                _y[1] = value + _y.Min();
                _riseYNotifiers();
            }
        }

        public double CenterX
        {
            get => (_x[0] + _x[1]) / 2 - _x.Min();
            set
            {
                var dx = value - (_x[0] + _x[1]) / 2 + _x.Min();
                StartPointX += dx;
                EndPointX += dx;
            }
        }

        public double CenterY
        {
            get => (_y[0] + _y[1]) / 2 - _y.Min();
            set
            {
                var dy = value - (_y[0] + _y[1]) / 2 + _y.Min();
                StartPointY += dy;
                EndPointY += dy;
            }
        }

        public HorizontalAlignment HorizontalAlignment =>
            StartPointX < EndPointX
                ? HorizontalAlignment.Left
                : HorizontalAlignment.Right;

        public VerticalAlignment VerticalAlignment =>
            StartPointY < EndPointY
                ? VerticalAlignment.Top
                : VerticalAlignment.Bottom;

        private void _riseXNotifiers()
        {
            OnPropertyChanged(nameof(StartPointX));
            OnPropertyChanged(nameof(EndPointX));
            OnPropertyChanged(nameof(PositionLeft));
            OnPropertyChanged(nameof(CenterX));
            OnPropertyChanged(nameof(HorizontalAlignment));
        }

        private void _riseYNotifiers()
        {
            OnPropertyChanged(nameof(StartPointY));
            OnPropertyChanged(nameof(EndPointY));
            OnPropertyChanged(nameof(PositionTop));
            OnPropertyChanged(nameof(CenterY));
            OnPropertyChanged(nameof(VerticalAlignment));
        }
    }
}
