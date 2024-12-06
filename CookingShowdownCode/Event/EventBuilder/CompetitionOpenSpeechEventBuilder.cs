using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.EventBuilder
{
    public class CompetitionOpenSpeechEventBuilder
    {
        public CompetitionOpenSpeechEventBuilder()
        {

        }

        public StardewValley.Event GenerateEvent()
        {
            GameEventScript script = new GameEventScript("", 0, 0, new List<NpcPosition>());


            return new StardewValley.Event(script.GenerateEventScript());
        }
    }
}
