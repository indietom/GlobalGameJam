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
        public particle(float x2, float y2, float minAng, float maxAng, string color, int type2)
        {
            Random random = new Random();
            angle = random.Next((int)minAng, (int)maxAng);
            setCoords(x2, y2);
            setSize(2, 2);
            accel = 10f;
            type = type2;
            switch (color)
            {
                case "red":
                    setSpriteCoords(76, 1);
                    break;
            }
        }
        public void movment()
        {
            switch (type)
            {
                case 1:
                    if (accel >= 0)
                    {
                        accel -= 1;
                    }
                    math(accel);
                    x += veclocity_x;
                    y += veclocity_y;
                    break;
            }
        }
    }
}
