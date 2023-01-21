using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleCad.Models;
using SimpleCad.UI;

namespace SimpleCad
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var project = new Project();
            project.Geometry.Add(new CircleGeometry()
            {
                Center = new PointGeometry(0,0),
                Radius = 100,
                Color = 52,
                Width = 3
            });
            var vm = new ProjectVm(project);
            vm.Load();

            MainWindow = new ProjectWindow(vm);
            MainWindow.Show();
        }
    }
}
