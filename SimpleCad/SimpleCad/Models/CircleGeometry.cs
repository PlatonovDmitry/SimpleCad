using System;

namespace SimpleCad.Models
{
    [Serializable]
    internal class CircleGeometry : ProjectGeometry
    {
        public PointGeometry Center { get; set; }
        public double Radius { get; set; }
    }
}
