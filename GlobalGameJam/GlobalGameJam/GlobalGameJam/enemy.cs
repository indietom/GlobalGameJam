using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class enemy:objects
    {
        public int type;

        public enemy(float x2, float y2, int type2)
        {
            setCoords(x2, y2);
            setSize(24, 24);
            type = type2;
            switch (type)
            {

            }
        }
    }
}
