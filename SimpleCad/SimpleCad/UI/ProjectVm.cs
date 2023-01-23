using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SimpleCad.Annotations;
using SimpleCad.Models;
using SimpleCad.UI.Geometry;

namespace SimpleCad.UI
{
    internal class ProjectVm : INotifyPropertyChanged
    {
        private Project _project;
        private ProjectGeometryVm _selectedGeometry;
        private ObservableCollection<ProjectGeometryVm> _geometry = new();

        public ProjectVm(Project project)
        {
            _project = project;

            AddLineCommand = new AddLineCommand(this);
            AddCircleCommand = new AddCircleCommand(this);
            AddRectangleCommand = new AddRectangleCommand(this);
        }

        public ObservableCollection<ProjectGeometryVm> Geometry
        {
            get => _geometry;
            set => _geometry = value;
        }

        public ProjectGeometryVm SelectedGeometry
        {
            get => _selectedGeometry;
            set
            {
                foreach (var curGeometry in Geometry)
                {
                    if (curGeometry != value)
                        curGeometry.IsSelected = false;
                }

                _selectedGeometry = value;
                if(value != null)
                    value.IsSelected = true;
                
                OnPropertyChanged(nameof(SelectedGeometry));
            }
        }

        public void Load()
        {
            foreach (var projectGeometry in _project.Geometry)
            {
                ProjectGeometryVm newGeometry = null;
                switch (projectGeometry)
                {
                    case CircleGeometry circle:
                        newGeometry = new CircleGeometryVm(circle);
                        break;
                    case LineGeometry line:
                        newGeometry = new LineGeometryVm(line);
                        break;
                    case RectangleGeometry rectangle:
                        newGeometry = new RectangleGeometryVm(rectangle);
                        break;
                }

                if(newGeometry != null)
                    Geometry.Add(newGeometry);
            }
        }

        public ICommand AddLineCommand { get; set; }

        public ICommand AddCircleCommand { get; set; }

        public ICommand AddRectangleCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
