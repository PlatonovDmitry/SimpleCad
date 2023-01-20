using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCad.Models
{
    internal class CircleGeometry : ProjectGeometry
    {
        public PointGeometry Center { get; set; }
        public double Radius { get; set; }
    }
}
