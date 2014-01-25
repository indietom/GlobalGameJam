using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class wall : objects
    {
        public wall(float x2, float y2)
        {
            setCoords(x2, y2);
            setSpriteCoords(1,451);
            setSize(16, 16);
            destroy = false;
            hp = 5;
        }
        public void checkHelath()
        {
            if (hp <= 0)
            {
                destroy = true;
            }
        }
    }
}
