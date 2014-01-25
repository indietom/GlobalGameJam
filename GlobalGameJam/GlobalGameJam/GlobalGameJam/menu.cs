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
    class menu : objects
    {
        public int select;
        public bool keyFalse;
        public bool keyFalse2;

        public menu()
        {
            select = 1;
            keyFalse = false;
            keyFalse2 = false;
        }

        public void menuUpdate()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (select >= 4)
            {
                select = 1;
            }
            if (select <= 0)
            {
                select = 3;
            }
            if (keyboard.IsKeyDown(Keys.Down) && !keyFalse)
            {
                select += 1;
                keyFalse = true;
            }
            if (keyboard.IsKeyDown(Keys.Up) && !keyFalse2)
            {
                select -= 1;
                keyFalse2 = true;
            }
            if (keyFalse)
            {
                if (keyboard.IsKeyUp(Keys.Down))
                {
                    keyFalse = false;
                }
            }
            if (keyFalse2)
            {
                if (keyboard.IsKeyUp(Keys.Up))
                {
                    keyFalse2 = false;
                }
            }
        }
        public void drawMenu(SpriteBatch spritebatch, SpriteFont font)
        {
            switch (select)
            {
                case 1:
                    spritebatch.DrawString(font, "-> Game \n Help \n Quit", new Vector2(400, 240), Color.White);
                    break;
                case 2:
                    spritebatch.DrawString(font, "Game \n-> Help \n Quit", new Vector2(400, 240), Color.White);
                    break;
                case 3:
                    spritebatch.DrawString(font, "Game \n Help \n-> Quit", new Vector2(400, 240), Color.White);
                    break;
            }
        }
    }
}
