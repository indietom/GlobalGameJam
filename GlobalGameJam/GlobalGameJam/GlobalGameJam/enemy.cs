﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class enemy:objects
    {
        public int type;
        public int steps;
        public int maxSteps;

        public enemy(float x2, float y2, int type2)
        {
            firerate = 0;
            setCoords(x2, y2);
            setSize(24, 24);
            type = type2;
            destroy = false;
            Random random = new Random();
            steps = 0;
            maxSteps = random.Next(150);
            switch (type)
            {
                case 1:
                    // Bonne
                    setSpriteCoords(1, 151);
                    hp = 5;
                    break;
                case 2:
                    //bone 
                    setSpriteCoords(1, 51);
                    hp = 3;
                    break;
                case 3:
                    //wizard
                    setSpriteCoords(1, 251);
                    hp = 7;
                    break;
            }
        }
        public void movment(List<enemyBullet> enemyBullets)
        {
            Random random = new Random();
            switch (type)
            {
                case 1:
                    mathAim(2, 400 - 16,240 - 16);
                    x += veclocity_x;
                    y += veclocity_y;
                    break;
                case 2:
                    mathAim(1, 400 - 16, 240 - 16);
                    steps += 1;
                    if (steps > maxSteps)
                    {
                        firerate += 1;
                        if (firerate == 64)
                        {
                            enemyBullets.Add(new enemyBullet(x + 12, y + 12, 1));
                            firerate = 0;
                        }
                    }
                    if (steps < maxSteps) 
                    {
                        x += veclocity_x;
                        y += veclocity_y;
                    }
                    break;
                case 3:
                    mathAim(1, 400 - 16, 240 - 16);
                    steps += 1;
                    if (steps < maxSteps) 
                    {
                        x += veclocity_x;
                        y += veclocity_y;
                    }
                    break;
            }
        }
    }
}
