using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class enemyBullet:objects
    {
        public int type;
        public float angle3;
        public enemyBullet(float x2, float y2, int type2)
        {
            setCoords(x2, y2);
            setSize(6, 6);
            type = type2;
            destroy = false;
            switch (type)
            {
                case 1:
                    setSpriteCoords(101,51);
                    break;
            }
        }
        public void movment()
        {
            mathAim(6, 400 - 16, 240 - 16);
            x += veclocity_x;
            y += veclocity_y;
        }
    }
}
