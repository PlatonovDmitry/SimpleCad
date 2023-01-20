using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleCad.Annotations;
using SimpleCad.Models;

namespace SimpleCad.UI
{
    internal class ProjectVm : INotifyPropertyChanged
    {
        private Project _project;
        private ProjectGeometry _selectedGeometry;

        public ProjectVm(Project project)
        {
            _project = project;
        }

        public ObservableCollection<ProjectGeometryVm> Geometry { get; set; } = new();

        public ProjectGeometry SelectedGeometry
        {
            get => _selectedGeometry;
            set
            {
                _selectedGeometry = value;
                OnPropertyChanged(nameof(SelectedGeometry));
            }
        }

        public void Load()
        {
            foreach (var projectGeometry in _project.Geometry)
            {
                Geometry.Add(new ProjectGeometryVm(projectGeometry));
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
