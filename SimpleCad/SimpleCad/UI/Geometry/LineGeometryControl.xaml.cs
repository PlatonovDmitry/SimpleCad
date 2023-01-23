using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleCad.UI.Geometry
{
    /// <summary>
    /// Interaction logic for LineGeometryControl.xaml
    /// </summary>
    public partial class LineGeometryControl : UserControl
    {
        public LineGeometryControl()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (DataContext is LineGeometryVm vm)
            {
                if (!vm.IsSelected)
                    vm.IsMouseOver = true;
            }
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (DataContext is LineGeometryVm vm)
            {
                vm.IsMouseOver = false;
            }
        }
    }
}
