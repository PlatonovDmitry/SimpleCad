using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleCad.Helpers
{
    internal static class ParentOfTypeExtension
    {
        public static T ParentOfType<T>(this DependencyObject element) where T : DependencyObject
        {
            if (element == null)
                return default;

            var curParent = VisualTreeHelper.GetParent(element);

            if (curParent == null)
                return default;

            if (curParent is T parent)
                return parent;

            return curParent.ParentOfType<T>();
        }
    }
}
