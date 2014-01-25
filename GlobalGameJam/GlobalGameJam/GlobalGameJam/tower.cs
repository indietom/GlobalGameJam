using System;
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
        public bool inputActive;

        public tower()
        {
            setCoords(400 - 16,240 - 16);
            setSpriteCoords(1, 1);
            setSize(32, 32);
            inputActive = true;
        }

        public void input(List<bullet> bullets)
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            if (inputActive)
            {
                if (firerate > 0)
                {
                    firerate += 1;

                    if (firerate >= 16)
                    {
                        firerate = 0;
                    }
                }

                if (mouse.LeftButton == ButtonState.Pressed && firerate == 0 && gunType == 0)
                {
                    bullets.Add(new bullet(x, y));
                    firerate = 1;
                }

            }

        }
    }
}
