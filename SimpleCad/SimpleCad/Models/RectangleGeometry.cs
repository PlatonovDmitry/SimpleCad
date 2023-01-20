using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCad.Models
{
    internal class RectangleGeometry : ProjectGeometry
    {
        public PointGeometry LeftBottom { get; set; }
        public PointGeometry RightTop { get; set; }
    }
}
