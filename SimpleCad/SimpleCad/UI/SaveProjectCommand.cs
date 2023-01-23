using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Input;
using Microsoft.Win32;
using SimpleCad.Helpers.Extensions;

namespace SimpleCad.UI
{
    internal class SaveProjectCommand : ICommand
    {
        private readonly MainVm _vm;

        public SaveProjectCommand(MainVm vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var project = _vm.Project.Save();

            var memoryStream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, project);

            var dialog =  new SaveFileDialog();
            dialog.Filter = "Simple CAD|*.scd";
            dialog.AddExtension = true;

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllBytes(dialog.FileName, memoryStream.ToArray());
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
