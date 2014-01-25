using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class particle:objects
    {
        public float accel;
        public int type;
        public particle(float x2, float y2, float randomAng, string color, int type2, float accel2)
        {
            Random random = new Random();
            angle = randomAng;
            setCoords(x2, y2);
            setSize(2, 2);
            accel = accel2;
            type = type2;
            switch (color)
            {
                case "red":
                    setSpriteCoords(76, 1);
                    break;
                case "white":
                    setSpriteCoords(76, 15);
                    break;
                case "orange":
                    setSpriteCoords(76, 7);
                    break;
                case "grey":
                    setSpriteCoords(76, 17);
                    break;
            }
        }
        public void movment()
        {
            switch (type)
            {
                case 1:
                    if (accel > 0)
                    {
                        accel -= 1f;
                    }
                    math(accel);
                    x += veclocity_x;
                    y += veclocity_y;
                    break;
            }
        }
    }
}
