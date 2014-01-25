using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class enemyBullet:objects
    {

        public int type;
        public enemyBullet(float x2, float y2, int type2)
        {
            setCoords(x2, y2);
            setSize(6, 6);
            type = type2;
            destroy = false;
            mathAim(6, 400, 240);
            switch (type)
            {
                case 1:
                    setSpriteCoords(101,51);
                    break;
                case 2:
                    setSpriteCoords(76, 251);
                    break;
            }
        }
        public void movment()
        {
            x += veclocity_x;
            y += veclocity_y;
        }
    }
}
