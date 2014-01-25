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
                case 1:
                    // Bonne
                    setSpriteCoords(1, 151);
                    hp = 5;
                    break;
                case 2:
                    //bone 
                    setSpriteCoords(1, 51);
                    hp = 3;
                    break;
                case 3:
                    //wizard
                    setSpriteCoords(1, 251);
                    hp = 7;
                    break;
            }
        }
        public void movment()
        {
            switch (type)
            {

            }
        }
    }
}
