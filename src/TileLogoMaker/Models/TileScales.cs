using System;

namespace KatsuYuzu.TileLogoMaker.Models
{
    [Flags]
    enum TileScales
    {
        Percent100 = 1,
        Percent80 = 2,
        Percent140 = 4,
        Percent180 = 8,
        GreaterThan100 = Percent100 | Percent140 | Percent180,
        All = GreaterThan100 | Percent80
    }
}
