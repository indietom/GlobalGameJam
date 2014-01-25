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
    class wizard : objects
    {
        public int gunType;
        public bool inputActive;
        public bool buttonFalse;

        public wizard()
        {
            angle = 0f;
            setCoords(384, 15);
            setSize(32, 32);
            setSpriteCoords(1, 1);
            inputActive = true;
        }
        public void input(List<enemy> enemies)
        {
            if (angle >= 360 || angle <= -360)
            {
                angle = 0;
            }
            KeyboardState keyboard = Keyboard.GetState();
            if (inputActive)
            {
                if (keyboard.IsKeyDown(Keys.D1))
                {
                    enemies.Add(new enemy(x, y, 1));
                }
                if (keyboard.IsKeyDown(Keys.D2))
                {
                    enemies.Add(new enemy(x, y, 2));
                }
                if (keyboard.IsKeyDown(Keys.D3))
                {
                    enemies.Add(new enemy(x, y, 3));
                }
                if (keyboard.IsKeyDown(Keys.A))
                {
                    angle += 0.55f;
                    x += veclocity_x;
                    y += veclocity_y;
                }
                if (keyboard.IsKeyDown(Keys.D))
                {
                    angle -= 0.55f;
                    x -= veclocity_x;
                    y -= veclocity_y;
                }
            }
            math(2);
        }
    }
}
