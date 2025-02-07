using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
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

        public MoveCmd(CharacterEnum character, ActorMove move)
        {
            this.CharacterEnum = character;
            this.x = move.x;
            this.y = move.y;
            this.facing = move.face;
            this.@continue = false;
        }

        public string getCommandString()
        {
            return $"move {CharacterEnum.GetName()} {x} {y} {facing} {(@continue ? "true" : "false")}";
        }
    }
}
