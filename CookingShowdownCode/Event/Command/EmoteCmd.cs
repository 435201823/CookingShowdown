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
        public string emoteId;

        public EmoteCmd(string npcId, string emoteId)
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
