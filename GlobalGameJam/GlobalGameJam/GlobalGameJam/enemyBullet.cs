using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class enemyBullet:objects
    {
        public int type;
        public enemyBullet(float x2, float y2, float angle3, int type2)
        {
            angle = angle3;
            setCoords(x2, y2);
            setSize(6, 6);
            type = type2;
            switch (type)
            {
                case 1:
                    setSpriteCoords(101,51);
                    break;
            }
        }
    }
}
