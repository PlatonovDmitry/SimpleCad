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
    /// Interaction logic for CircleGeometryControl.xaml
    /// </summary>
    public partial class CircleGeometryControl : UserControl
    {
        public CircleGeometryControl()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (this.DataContext is CircleGeometryVm circle)
            {
                if (!circle.IsSelected)
                    circle.IsMouseOver = true;
            }
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (this.DataContext is CircleGeometryVm circle)
            {
                circle.IsMouseOver = false;
            }
            
        }

        private void UIElement_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
