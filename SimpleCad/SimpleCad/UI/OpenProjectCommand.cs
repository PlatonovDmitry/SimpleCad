using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Input;
using Microsoft.Win32;
using SimpleCad.Helpers.Extensions;

namespace SimpleCad.UI
{
    internal class OpenProjectCommand : ICommand
    {
        private readonly MainVm _vm;

        public OpenProjectCommand(MainVm vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Simple CAD|*.scd";
            if (dialog.ShowDialog()== true)
            {
                var formatter = new BinaryFormatter();
                using var readStream = File.OpenRead(dialog.FileName);
                {
                    var bytes = formatter.Deserialize(readStream);
                    if (bytes is Models.Project project)
                        _vm.Project = project.Load();
                }
                
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}