using CookingShowdownCode.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class EmoteCmd : GameEventCommand
    {
        public string npcId;
        public int emoteId;

        public EmoteCmd(CharacterEnum character, EmoteEnum emoteId):this(character.GetName(), (int)emoteId)
        {
        }

        public EmoteCmd(string npcId, int emoteId)
        {
            this.npcId = npcId;
            this.emoteId = emoteId;
        }

        public string getCommandString()
        {
            return "emote " + npcId + " " + emoteId;
        }
    }
}
