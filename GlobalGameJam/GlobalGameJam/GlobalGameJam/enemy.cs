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
        public int attackCounter;
        public bool running;

        public enemy(float x2, float y2, int type2)
        {
            animatioCount = 0;
            animationActive = true;
            firerate = 0;
            setCoords(x2, y2);
            setSize(24, 24);
            type = type2;
            destroy = false;
            attackCounter = 0;
            Random random = new Random();
            steps = 0;
            running = true;
            maxSteps = random.Next(10, 140);
            switch (type)
            {
                case 1:
                    // Bonne
                    setSpriteCoords(1, 151);
                    hp = 2;
                    break;
                case 2:
                    //bone 
                    setSpriteCoords(1, 51);
                    hp = 3;
                    break;
                case 3:
                    //wizard
                    setSpriteCoords(1, 251);
                    hp = 4;
                    break;
            }
        }
        public void checkHealth(List<blood> bloodSplatters, List<particle> particles)
        {
            Random random = new Random();
            if (hp <= 0)
            {
                if (type == 1 || type == 3)
                {
                    bloodSplatters.Add(new blood(x, y));
                    for (int i = 0; i < 70; i++)
                    {
                        particles.Add(new particle(x + 12, y + 12, random.Next(360), "red", 1, random.Next(5, 50)));
                    }
                }
                if (type == 2)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        particles.Add(new particle(x + 12, y + 12, random.Next(360), "white", 1, random.Next(5, 50)));
                    }
                }
                destroy = true;
            }
        }
        public void animation()
        {
            if (animationActive)
            {
                animatioCount += 1;
                if (animatioCount == 10)
                {
                    imx += 25;
                    animatioCount = 0;
                }
                if (imx == 76)
                {
                    imx = 1;
                }
            }
        }
        public void movment(List<enemyBullet> enemyBullets)
        {
            Random random = new Random();
            switch (type)
            {
                case 1:
                    mathAim(1, 400 - 10,240 - 16);
                    if (running)
                    {
                        x += veclocity_x;
                        y += veclocity_y;
                    }
                    attackCounter += 1;
                    if (attackCounter >= 21)
                    {
                          attackCounter = 0;
                    }
                    break;
                case 2:
                    mathAim(1, 396+6, 249+6);
                    steps += 1;
                    if (steps > maxSteps)
                    {
                        firerate += 1;
                        if (firerate == 64*2)
                        {
                            enemyBullets.Add(new enemyBullet(x + 12, y + 12, 1));
                            firerate = random.Next(20);
                        }
                        animationActive = false;
                        imx = 1;
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
                    if (steps > maxSteps)
                    {
                        firerate += 1;
                        if (firerate == 64 * 3)
                        {
                            enemyBullets.Add(new enemyBullet(x + 12, y + 12, 1));
                            firerate = random.Next(20);
                        }
                        animationActive = false;
                        imx = 1;
                    }
                    break;
            }
        }
    }
}
