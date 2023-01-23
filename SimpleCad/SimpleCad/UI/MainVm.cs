using System.Windows.Input;
using SimpleCad.Helpers;
using SimpleCad.UI.Project;

namespace SimpleCad.UI
{
    internal class MainVm : NotifyObject
    {
        private ProjectVm _project;

        public MainVm()
        {
            _project = new ProjectVm();
            SaveCommand = new SaveProjectCommand(this);
            OpenCommand = new OpenProjectCommand(this);
            NewProjectCommand = new NewProjectCommand(this);
        }

        public ProjectVm Project
        {
            get => _project;
            set => Set(ref _project, value);
        }

        public ICommand SaveCommand { get; }

        public ICommand OpenCommand { get; }

        public ICommand NewProjectCommand { get; }
    }
}
