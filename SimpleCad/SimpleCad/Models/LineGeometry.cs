using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCad.Models
{
    [Serializable]
    internal class LineGeometry : ProjectGeometry
    {
        public PointGeometry StartPoint { get; set; }

        public PointGeometry EndPoint { get; set; }
    }
}
