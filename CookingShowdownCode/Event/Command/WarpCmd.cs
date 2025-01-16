using CookingShowdownCode.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class WarpCmd : GameEventCommand
    {
        private CharacterEnum actor;
        private int x;
        private int y;

        public WarpCmd(CharacterEnum actor, int x,int y) 
        {
            this.actor = actor;
            this.x = x;
            this.y = y;
        }

        public string getCommandString()
        {
            return $"warp {actor.GetName()} {x} {y}";
        }
    }
}
