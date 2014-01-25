using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGameJam
{
    class wizard : objects
    {
        public int gunType;
        public bool inputActive;
        public bool buttonFalse;

        public wizard()
        {
            setCoords(384, 0);
            setSize(32, 32);
            setSpriteCoords(1, 1);
        }
    }
}
