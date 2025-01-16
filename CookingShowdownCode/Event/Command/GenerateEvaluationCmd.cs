using CookingShowdownCode.Event.EventBuilder;
using CookingShowdownCode.Helper;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    internal class GenerateEvaluationCmd : GameEventCommand
    {
        public string getCommandString()
        {
            return "generateEvaluation";
        }

        public static void GenerateEvaluation(StardewValley.Event @event, string[] args, EventContext context)
        {
            var finishEvent = new CompetitionFinishEventBuilder()
                .Build();

            GameEventHelper.eventInsertNextCommandList(@event, finishEvent);

            ++@event.currentCommand;
        }

        
    }
}
