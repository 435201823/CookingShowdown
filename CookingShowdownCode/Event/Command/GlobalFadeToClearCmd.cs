using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class GlobalFadeToClearCmd : GameEventCommand
    {
        private double speed;

        private bool @continue;


        public GlobalFadeToClearCmd(double speed, bool @continue)
        {
            this.speed = speed;
            this.@continue = @continue;
        }

        public string getCommandString()
        {
            return $"globalFadeToClear {speed} {@continue}";
        }
    }
}
