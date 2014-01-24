using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class tower : objects
    {

        public int gunType;
        public int fireRate;

        public tower()
        {
            setCoords(400 - 16,240 - 16);
            setSpriteCoords(1, 1);
            setSize(32, 32);

        }
    }
}
