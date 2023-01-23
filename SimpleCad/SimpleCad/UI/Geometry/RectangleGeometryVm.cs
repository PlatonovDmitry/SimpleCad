using System;
using System.Linq;
using System.Windows;
using SimpleCad.Helpers;
using SimpleCad.Models;

namespace SimpleCad.UI.Geometry
{
    
    internal class RectangleGeometryVm : ProjectGeometryVm
    {
        private double[] _y;
        private double[] _x;

        public RectangleGeometryVm(RectangleGeometry geometry) : base(geometry)
        {
            _x = new[] { Constants.FIELD_CENTER_X + geometry.LeftTop.X, Constants.FIELD_CENTER_X + geometry.RightBottom.X };
            _y = new[] { Constants.FIELD_CENTER_Y - geometry.LeftTop.Y, Constants.FIELD_CENTER_Y - geometry.RightBottom.Y };
        }

        public override double PositionLeft => _x.Min();
        public override double PositionTop => _y.Min();

        public double Width
        {
            get
            {
                var width = _x[0] - _x[1];
                return Math.Sign(width) * width;
            }
        }

        public double Height
        {
            get
            {
                var height = _y[0] - _y[1];
                return Math.Sign(height) * height;
            }
        }

        public double LeftTopX
        {
            get => _x[0];
            set
            {
                _x[0] = value;
                OnPropertyChanged(nameof(LeftTopX));
                _riseXNotifiers();
            }
        }

        public double RightBottomX
        {
            get => _x[1];
            set
            {
                _x[1] = value;
                OnPropertyChanged(nameof(RightBottomX));
                _riseXNotifiers();
            }
        }

        public double LeftTopY
        {
            get => _y[0];
            set
            {
                _y[0] = value;
                OnPropertyChanged(nameof(LeftTopY));
                _riseYNotifiers();
            }
        }

        public double RightBottomY
        {
            get => _y[1];
            set
            {
                _y[1] = value;
                OnPropertyChanged(nameof(RightBottomY));
                _riseYNotifiers();
            }
        }

        public double CenterX
        {
            get => (_x[0] + _x[1]) / 2;
            set
            {
                var dx = value - (_x[0] + _x[1]) / 2;
                LeftTopX += dx;
                RightBottomX += dx;
            }
        }

        public double CenterY
        {
            get => (_y[0] + _y[1]) / 2;
            set
            {
                var dy = value - (_y[0] + _y[1]) / 2;
                LeftTopY += dy;
                RightBottomY += dy;
            }
        }

        public HorizontalAlignment HorizontalAlignment =>
            LeftTopX < RightBottomX
                ? HorizontalAlignment.Left
                : HorizontalAlignment.Right;

        public VerticalAlignment VerticalAlignment =>
            LeftTopY < RightBottomY
                ? VerticalAlignment.Top
                : VerticalAlignment.Bottom;

        private void _riseXNotifiers()
        {
            OnPropertyChanged(nameof(PositionLeft));
            OnPropertyChanged(nameof(Width));
            OnPropertyChanged(nameof(CenterX));
            OnPropertyChanged(nameof(HorizontalAlignment));
        }

        private void _riseYNotifiers()
        {
            OnPropertyChanged(nameof(PositionTop));
            OnPropertyChanged(nameof(Height));
            OnPropertyChanged(nameof(CenterY));
            OnPropertyChanged(nameof(VerticalAlignment));
        }
    }
}
