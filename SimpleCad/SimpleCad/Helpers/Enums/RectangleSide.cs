using System;

namespace SimpleCad.Helpers.Enums
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
