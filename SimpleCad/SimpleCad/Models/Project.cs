using System;
using System.Collections.Generic;

namespace SimpleCad.Models
{
    [Serializable]
    internal class Project
    {
        public string Name { get; set; }

        public List<ProjectGeometry> Geometry { get; set; } = new ();
    }
}
