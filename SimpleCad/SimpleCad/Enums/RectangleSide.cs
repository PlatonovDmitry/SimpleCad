using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCad.Enums
{
    [Flags]
    internal enum RectangleSide
    {
        Left=1,
        Right=2,
        Top=4,
        Bottom=8,
        All = Left | Right | Top | Bottom,
    }
}
