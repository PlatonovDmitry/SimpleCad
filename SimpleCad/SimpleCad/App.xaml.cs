using System.Windows;
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
            var vm = new MainVm();
            
            MainWindow = new MainWindow(vm);
            MainWindow.Show();
        }
    }
}
