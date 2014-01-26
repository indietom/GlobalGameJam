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
            spriteBatch.DrawString(font, "A evil wizard has taken the residents of your village\n   under control using magic! You have to stop him \n           before he destroys your tower!", new Vector2(100, 10), Color.White);
            spriteBatch.DrawString(font, "Player 1: left mouse button to shoot, right mouse button to use powerups", new Vector2(5, 100), Color.White);
            spriteBatch.DrawString(font, "Player 2: spawns villagers with 1, skeletons with 2, mini-wizards \n   with 3, S to use spells and moves in a circle with A and D.", new Vector2(5, 125), Color.White);
            spriteBatch.DrawString(font, "   Press Enter to start\nBetween Archers and Wizard!", new Vector2(250, 200), Color.White);
        }
        public void input(ref string gameState)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Enter))
            {
                gameState = "game";
            }
        }
        }
    }

