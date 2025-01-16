using CookingShowdownCode.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class MoveCmd : GameEventCommand
    {
        private CharacterEnum CharacterEnum;
        private int x;
        private int y;
        private DirectionEnum facing;
        private bool @continue;

        public MoveCmd(CharacterEnum character, int x, int y, DirectionEnum facing, bool @continue = false)
        {
            this.CharacterEnum = character;
            this.x = x;
            this.y = y;
            this.facing = facing;
            this.@continue = @continue;
        }

        public string getCommandString()
        {
            return $"move {CharacterEnum.GetName()} {x} {y} {facing} {(@continue ? "true" : "false")}";
        }
    }
}
