using System;
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

            var val = BitConverter.ToInt32(new byte[] { 0, 255, 0, 0 }, 0);

            project.Geometry.Add(new CircleGeometry()
            {
                Center = new PointGeometry(0,0),
                Radius = 100,
                Color = val,
                Thickness = 3
            });

            project.Geometry.Add(new RectangleGeometry()
            {
                LeftTop = new PointGeometry(100, 100),
                RightBottom = new PointGeometry(200, -100),
                Color = val,
                Thickness = 3
            });


            var vm = new ProjectVm(project);
            vm.Load();

            MainWindow = new ProjectWindow(vm);
            MainWindow.Show();
        }
    }
}
