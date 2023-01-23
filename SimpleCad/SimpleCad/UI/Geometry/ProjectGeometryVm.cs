using System.Windows.Media;
using SimpleCad.Helpers;

namespace SimpleCad.UI.Geometry
{
    internal abstract class ProjectGeometryVm : NotifyObject
    {
        private Color _color;
        private int _thickness;
        private bool _isMouseOver;
        private bool _isSelected;

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
