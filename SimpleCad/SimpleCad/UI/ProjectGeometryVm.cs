using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimpleCad.Annotations;
using SimpleCad.Models;

namespace SimpleCad.UI
{
    internal class ProjectGeometryVm : INotifyPropertyChanged
    {
        protected ProjectGeometry _geometry;
        private int _color;
        private int _width;

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


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
