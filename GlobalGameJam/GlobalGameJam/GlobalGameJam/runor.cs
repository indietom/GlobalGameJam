using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class runor:objects
    {
        public int type;
        public int lifeTime;

        public void checkLifeTime()
        {
            lifeTime += 1;
            if (lifeTime >= 64*20)
            {
                destroy = true;
            }
        }
        public void movment()
        {
            x += veclocity_x;
            y += veclocity_y;
            math(1);
        }
        public runor()
        {
            Random random = new Random();
            setCoords(random.Next(690), random.Next(480));
            setSize(24, 24);
            destroy = false;
            type = random.Next(1, 4);
            lifeTime = 0;
            angle = random.Next(360);
            switch (type)
            {
                case 1:
                    setSpriteCoords(1, 376);
                    break;
                case 2:
                    setSpriteCoords(26, 376);
                    break;
                case 3:
                    setSpriteCoords(51, 376);
                    break;
            }
        }
    }
}
