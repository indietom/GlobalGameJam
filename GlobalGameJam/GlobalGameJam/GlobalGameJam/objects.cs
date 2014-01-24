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
    class objects
    {
        public float x;
        public float y;
        public int width;
        public int height;
        public int imx;
        public int imy;
        public int hp;

        public bool destroy;

        public void setCoords(float x2, float y2)
        {
            x = x2;
            y = y2;
        }
        public void setSpriteCoords(int imx2, int imy2)
        {
            imx = imx2;
            imy = imy2;
        }
        public void size(int w2, int h2)
        {
            width = w2;
            height = h2;
        }
        public void drawSprite(SpriteBatch spritebatch, Texture2D spritesheet)
        {
            spritebatch.Draw(spritesheet, new Vector2(x, y), new Rectangle(imx, imy, width, height), Color.White);
        }
    }
}
