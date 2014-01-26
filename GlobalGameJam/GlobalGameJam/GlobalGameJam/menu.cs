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
        public int selected;

        public bool keyFalse1;
        public bool keyFalse2;

        public menu()
        {
            selected = 1;
            keyFalse1 = false;
            keyFalse2 = false;
        }
        public void drawMenu(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, "Player 2 spawns villegers with 1, skeletons \n with 2 and mini-wizards with 3 and moves \n in a circle with A and D", new Vector2(300, 240), Color.White);
            spriteBatch.DrawString(font, "Player 1 aims and shoots with the mouse", new Vector2(300, 340), Color.White);
            switch (selected)
            {
                case 1:
                    spriteBatch.DrawString(font, "-> Start Game \n How to \n Quit ", new Vector2(100, 240), Color.White);
                    break;
                case 2:
                    spriteBatch.DrawString(font, "Start Game \n-> How to \n Quit ", new Vector2(100, 240), Color.White);
                    break;
                case 3:
                    spriteBatch.DrawString(font, "Start Game \n How to \n-> Quit ", new Vector2(100, 240), Color.White);
                    break;
            }
        }
        public void input(ref string gameState)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (selected == 0)
            {
                selected = 3;
            }
            if (selected == 4)
            {
                selected = 1;
            }
            if (selected == 1 && keyboard.IsKeyDown(Keys.Enter))
            {
                gameState = "game";
            }
            if (selected == 3 && keyboard.IsKeyDown(Keys.Enter))
            {
                Environment.Exit(0);
            }
            if (keyFalse1)
            {
                if (keyboard.IsKeyUp(Keys.Up))
                {
                    keyFalse1 = false;
                }
            }
            if (keyFalse2)
            {
                if (keyboard.IsKeyUp(Keys.Down))
                {
                    keyFalse2 = false;
                }
            }
            if (keyboard.IsKeyDown(Keys.Down) && !keyFalse2)
            {
                selected += 1;
                keyFalse2 = true;
            }
            if (keyboard.IsKeyDown(Keys.Up) && !keyFalse1)
            {
                selected -= 1;
                keyFalse1 = true;
            }
        }
    }
}
