using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimpleCad.Annotations;
using SimpleCad.Models;

namespace SimpleCad.UI.Geometry
{
    internal class ProjectGeometryVm : INotifyPropertyChanged
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


        public int Color
        {
            get => _color;
            set
            {
                _color = value; 
                OnPropertyChanged(nameof(Color));
            }
        }

        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public bool IsMouseOver
        {
            get => _isMouseOver;
            set
            {
                _isMouseOver = value;
                OnPropertyChanged(nameof(IsMouseOver));
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
