using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCad.Models
{
    internal class Project
    {
        public string Name { get; set; }

        public List<ProjectGeometry> Geometry { get; set; } = new ();
    }
}
