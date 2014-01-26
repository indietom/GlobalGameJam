using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class powerUp:objects
    {
        public int type;
        public powerUp()
        {
            Random random = new Random();
            setCoords(random.Next(800), random.Next(480));
            setSize(24, 24);
            destroy = false;
            type = random.Next(1, 4);
            switch (type)
            {
                case 1:
                    setSpriteCoords(1, 401);
                    break;
                case 2:
                    setSpriteCoords(26, 401);
                    break;
                case 3:
                    setSpriteCoords(51 , 401);
                    break;
            }
        }
    }
}
