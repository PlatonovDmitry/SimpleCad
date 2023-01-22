using SimpleCad.Helpers;
using SimpleCad.Models;

namespace SimpleCad.UI.Geometry
{
    internal abstract class ProjectGeometryVm : NotifyObject
    {
        protected ProjectGeometry _geometry;
        private int _color;
        private int _width;
        private bool _isMouseOver;
        private bool _isSelected;

        public ProjectGeometryVm(ProjectGeometry geometry)
        {
            _geometry = geometry;

            Color = geometry.Color;
            Width = geometry.Width;
        }

        public abstract double PositionLeft { get; set; }

        public abstract double PositionTop { get; set; }


        public int Color
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
