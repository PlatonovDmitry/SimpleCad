using System;
using System.Windows.Media;
using SimpleCad.Helpers;
using SimpleCad.Models;

namespace SimpleCad.UI.Geometry
{
    internal abstract class ProjectGeometryVm : NotifyObject
    {
        protected ProjectGeometry _geometry;
        private Color _color;
        private int _thickness;
        private bool _isMouseOver;
        private bool _isSelected;

        public ProjectGeometryVm(ProjectGeometry geometry)
        {
            _geometry = geometry;

            byte[] arrBytes = BitConverter.GetBytes(geometry.Color);
            // Распределение байт
            //byte a = arrBytes[3];
            byte r = arrBytes[0];
            byte g = arrBytes[1];
            byte b = arrBytes[2];

            Color = Color.FromRgb(r, g, b);
            Thickness = geometry.Thickness;
        }

        public abstract double PositionLeft { get; }

        public abstract double PositionTop { get; }


        public Color Color
        {
            get => _color;
            set => Set(ref _color, value);
        }

        public int Thickness
        {
            get => _thickness;
            set => Set(ref _thickness, value);
        }

        public bool IsMouseOver
        {
            get => _isMouseOver;
            set => Set(ref _isMouseOver, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }

    }
}
