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
                .BuildEvaluateTmp();

            int index = @event.currentCommand + 1;
            List<string> list = ((IEnumerable<string>)@event.eventCommands).ToList<string>();
            if (index <= list.Count)
            {
                foreach (var command in finishEvent)
                {
                    list.Insert(index++, command);
                }
            }
            else
            {
                foreach (var command in finishEvent)
                {
                    list.Add(command);
                }
            }
            @event.eventCommands = list.ToArray();

            ++@event.currentCommand;
        }

        
    }
}
