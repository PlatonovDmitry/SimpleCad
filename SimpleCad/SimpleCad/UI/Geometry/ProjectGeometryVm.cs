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
        private int _width;
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
            Width = geometry.Width;
        }

        public abstract double PositionLeft { get; set; }

        public abstract double PositionTop { get; set; }


        public Color Color
        {
            get => _color;
            set => Set(ref _color, value);
        }

        public int Width
        {
            get => _width;
            set => Set(ref _width, value);
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
