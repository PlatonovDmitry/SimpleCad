using System;
using System.Windows.Input;
using SimpleCad.UI.Project;

namespace SimpleCad.UI
{
    internal class NewProjectCommand : ICommand
    {
        private readonly MainVm _vm;

        public NewProjectCommand(MainVm vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _vm.Project = new ProjectVm();
        }

        public event EventHandler CanExecuteChanged;
    }
}
