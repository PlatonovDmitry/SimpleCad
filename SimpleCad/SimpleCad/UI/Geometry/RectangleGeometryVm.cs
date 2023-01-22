using System;
using System.Linq;
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
                if(value < _x[1])
                {
                    _x[0] = value;
                    OnPropertyChanged(nameof(LeftTopX));
                    OnPropertyChanged(nameof(PositionLeft));
                    OnPropertyChanged(nameof(Width));
                    OnPropertyChanged(nameof(CenterX));
                }
            }
        }

        public double RightBottomX
        {
            get => _x[1];
            set
            {
                if(value > _x[0])
                {
                    _x[1] = value;
                    OnPropertyChanged(nameof(RightBottomX));
                    OnPropertyChanged(nameof(PositionLeft));
                    OnPropertyChanged(nameof(Width));
                    OnPropertyChanged(nameof(CenterX));
                }
            }
        }

        public double LeftTopY
        {
            get => _y[0];
            set
            {
                if(value < _y[1])
                {
                    _y[0] = value;
                    OnPropertyChanged(nameof(LeftTopY));
                    OnPropertyChanged(nameof(PositionTop));
                    OnPropertyChanged(nameof(Height));
                    OnPropertyChanged(nameof(CenterY));
                }
            }
        }

        public double RightBottomY
        {
            get => _y[1];
            set
            {
                if(value > _y[0])
                {
                    _y[1] = value;
                    OnPropertyChanged(nameof(RightBottomY));
                    OnPropertyChanged(nameof(PositionTop));
                    OnPropertyChanged(nameof(Height));
                    OnPropertyChanged(nameof(CenterY));
                }
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
    }
}
