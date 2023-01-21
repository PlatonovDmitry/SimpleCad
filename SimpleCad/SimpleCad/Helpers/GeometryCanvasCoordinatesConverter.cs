using System;
using System.Globalization;
using System.Windows.Data;
using SimpleCad.UI;
using SimpleCad.UI.Geometry;

namespace SimpleCad.Helpers
{
    internal class GeometryCanvasCoordinatesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isX = parameter is true;
            
            switch (value)
            {
                case CircleGeometryVm circle:
                    return 100 - (isX ? circle.Center.X : circle.Center.Y);
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
