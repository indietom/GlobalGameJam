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
        public int magicSpell;
        public int undoSpell;

        public void reset()
        {
            magicSpell = 1;
            angle = 0f;
            setCoords(384, 15);
            setSize(32, 32);
            setSpriteCoords(1, 1);
            inputActive = true;
            hp = 10;
            mana = 100;
            undoSpell = 0;
        }

        public wizard()
        {
            reset();
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
        public void input(List<enemy> enemies, ref bool inputActive2, List<enemyBullet> enemyBullets)
        {
            if (angle >= 360 || angle <= -360)
            {
                angle = 0;
            }
            KeyboardState keyboard = Keyboard.GetState();
            if (inputActive)
            {
                if (magicSpell == 3 && keyboard.IsKeyDown(Keys.Q))
                {
                    inputActive2 = false;
                    undoSpell = 1;
                    magicSpell = 0;
                }
                if (magicSpell == 1 && keyboard.IsKeyDown(Keys.Q))
                {
                    for (int i = 0; i < 20; i++)
                    {
                        enemyBullets.Add(new enemyBullet(x + 16 + i*5, y + 16, 3));
                    }
                    magicSpell = 0;
                }
                if (undoSpell >= 1)
                {
                    undoSpell += 1;
                    if (undoSpell >= 64*2)
                    {
                        inputActive2 = true;
                        undoSpell = 0;
                    }
                }
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
