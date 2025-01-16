using CookingShowdownCode.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class FaceDirectionCmd : GameEventCommand
    {
        private CharacterEnum character;
        private DirectionEnum direction;
        private bool @continue;

        public FaceDirectionCmd(CharacterEnum character, DirectionEnum direction, bool @continue = false) 
        {
            this.character = character;
            this.direction = direction;
            this.@continue = @continue;
        }

        public string getCommandString()
        {
            return $"faceDirection {character.GetName()} {direction} {@continue}";
        }
    }
}
