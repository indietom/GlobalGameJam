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

        public bullet(float x2,float y2)
        {
            setCoords(x2,y2);
            setSpriteCoords(1, 1);
            setSize(64, 64);
            MouseState mouse = Mouse.GetState();
            mathAim(8, mouse.X, mouse.Y);
        }
        public void movment()
        {
            MouseState mouse = Mouse.GetState();
            x += veclocity_x;
            y += veclocity_y;
        }
    }
}
