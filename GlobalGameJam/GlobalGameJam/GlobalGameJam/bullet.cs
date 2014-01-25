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
    class bullet : objects
    {
        public int type;

        public bullet(float x2,float y2, float x3, float y3)
        {
            setCoords(x2,y2);
            setSpriteCoords(27, 307);
            setSize(12, 5);
            MouseState mouse = Mouse.GetState();
            mathAim(5, x3, y3);
            destroy = false;

        }
        public void movment()
        {
            x += veclocity_x;
            y += veclocity_y;
        }
    }
}
