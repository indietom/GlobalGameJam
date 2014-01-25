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
            setSpriteCoords(2,451);
            setSize(16, 16);
            destroy = false;
            hp = 15;
        }
        public void checkHelath(List<particle> particles)
        {
            Random random = new Random();
            if (hp <= 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    particles.Add(new particle(x + 12, y + 12, random.Next(360), "orange", 1, random.Next(5, 20)));
                }
                destroy = true;
            }
        }
    }
}
