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
                    return 200 + (isX 
                        ? circle.CenterX - circle.Diametr / 2 
                        : -circle.Diametr / 2 - circle.CenterY);
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
