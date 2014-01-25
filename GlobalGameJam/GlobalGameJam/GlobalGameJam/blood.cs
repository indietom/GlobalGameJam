using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class blood:objects
    {
        public blood(float x2,float y2)
        {
            setCoords(x2, y2);
            setSpriteCoords(1, 351);
            setSize(24, 24);
            destroy = false;
        }
    }
}
