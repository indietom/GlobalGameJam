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
        public int firerate;

        public float speed;
        public float angle;
        public float angle2;
        public float scale_x;
        public float scale_y;
        public float veclocity_x;
        public float veclocity_y;

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
        public void setSize(int w2, int h2)
        {
            width = w2;
            height = h2;
        }
        public void drawSprite(SpriteBatch spritebatch, Texture2D spritesheet)
        {
            spritebatch.Draw(spritesheet, new Vector2(x, y), new Rectangle(imx, imy, width, height), Color.White);
        }

        public void math(float speed2)
        {
            angle2 = (angle * (float)Math.PI / 180);
            speed = speed2;
            scale_x = (float)Math.Cos(angle2);
            scale_y = (float)Math.Sin(angle2);
            veclocity_x = (speed * scale_x);
            veclocity_y = (speed * scale_y);
        }
        public void mathAim(float speed2, float x2, float y2)
        {
            angle = (float)Math.Atan2(y2 - y, x2 - x);
            speed = speed2;
            veclocity_x = (speed * (float)Math.Cos(angle));
            veclocity_y = (speed * (float)Math.Sin(angle));
        }

        
    }
}
