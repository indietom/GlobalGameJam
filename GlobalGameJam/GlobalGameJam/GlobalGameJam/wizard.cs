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
        public bool keyFalse;
        public bool keyFalse2;
        public bool keyFalse3;
        public int mana;
        public int countToMana;

        public void reset()
        {
            angle = 0f;
            setCoords(384, 15);
            setSize(32, 32);
            setSpriteCoords(1, 1);
            inputActive = true;
            hp = 10;
            mana = 1000;
        }

        public wizard()
        {
            angle = 0f;
            setCoords(384, 15);
            setSize(32, 32);
            setSpriteCoords(1, 1);
            inputActive = true;
            hp = 10;
            mana = 1000;
        }
        public void checkHelath()
        {
            if (hp <= 0)
            {
                inputActive = false;
                imx = 34;
            }
        }
        public void manaAdding()
        {
            countToMana += 1;
            if (countToMana == 64 * 5)
            {
                mana += 5;
                countToMana = 0;
            }
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
                if (keyFalse)
                {
                    if (keyboard.IsKeyUp(Keys.D1))
                    {
                        keyFalse = false;
                    }
                }
                if (keyFalse2)
                {
                    if (keyboard.IsKeyUp(Keys.D2))
                    {
                        keyFalse2 = false;
                    }
                }
                if (keyFalse3)
                {
                    if (keyboard.IsKeyUp(Keys.D3))
                    {
                        keyFalse3 = false;
                    }
                }
                if (keyboard.IsKeyDown(Keys.D1) && mana >= 10 && !keyFalse)
                {
                    enemies.Add(new enemy(x, y, 1));
                    mana -= 10;
                    keyFalse = true;
                }
                if (keyboard.IsKeyDown(Keys.D2) && mana >= 30 && !keyFalse2)
                {
                    enemies.Add(new enemy(x, y, 2));
                    mana -= 20;
                    keyFalse2 = true;
                }
                if (keyboard.IsKeyDown(Keys.D3) && mana >= 50 && !keyFalse3)
                {
                    enemies.Add(new enemy(x, y, 3));
                    mana -= 50;
                    keyFalse3 = true;
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
