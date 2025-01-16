using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    internal class ViewportCmd : GameEventCommand
    {
        private static int oldX = 0;
        private static int oldY = 0;
        private int x;
        private int y;

        public ViewportCmd(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static ViewportCmd viewPortBlack(int x,int y)
        {
            oldX = x;
            oldY = y;
            return new ViewportCmd(-1000, -1000);
        }

        public static ViewportCmd viewPortReturn()
        {
            return new ViewportCmd(oldX, oldY);
        }

        public string getCommandString()
        {
            return $"viewport {x} {y}";
        }
    }
}
