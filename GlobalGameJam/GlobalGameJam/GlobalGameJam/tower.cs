﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GlobalGameJam
{
    class tower : objects
    {

        public int gunType;
        public int powerUpActive;
        public bool inputActive;
        public bool buttonFalse;

        public void reset()
        {
            setCoords(400 - 16, 240 - 16);
            setSpriteCoords(1, 301);
            setSize(24, 49);
            inputActive = true;
            gunType = 2;
            hp = 50;
        }

        public tower()
        {
            reset();
        }
        public void checkPowerUp()
        {
            if (powerUpActive >= 1)
            {
                powerUpActive += 1;
                if (powerUpActive >= 64 * 7)
                {
                    gunType = 0;
                    powerUpActive = 0;
                }
            }
        }
        public void checkHelath()
        {
            if (hp <= 0)
            {
                inputActive = false;
                setSpriteCoords(26, 326);
            }
        }
        public void input(List<bullet> bullets)
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            if (inputActive)
            {
                if (firerate >= 1)
                {
                    firerate += 1;

                    if (firerate >= 64+24)
                    {
                        firerate = 0;
                    }
                }

                if (mouse.LeftButton == ButtonState.Pressed && firerate <= 0 && gunType == 0 && buttonFalse == false)
                {
                    bullets.Add(new bullet(x+12, y, mouse.X, mouse.Y));
                    firerate = 1;
                    buttonFalse = true;
                }
                if (mouse.LeftButton == ButtonState.Pressed && firerate <= 0 && gunType == 1 && buttonFalse == false)
                {
                    bullets.Add(new bullet(x + 12, y, mouse.X - 20, mouse.Y));
                    bullets.Add(new bullet(x + 12, y, mouse.X, mouse.Y));
                    bullets.Add(new bullet(x + 12, y, mouse.X + 20, mouse.Y));
                    firerate = 1;
                    buttonFalse = true;
                }
                if (mouse.LeftButton == ButtonState.Pressed && firerate <= 0 && gunType == 2)
                {
                    bullets.Add(new bullet(x + 12, y, mouse.X, mouse.Y));
                    firerate = 70;
                }

                if (buttonFalse)
                {
                    if (mouse.LeftButton == ButtonState.Released)
                    {
                        buttonFalse = false;
                    }
                }

            }

        }
    }
}
