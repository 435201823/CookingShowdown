using CookingShowdownCode.Event.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Helper
{
    public class GameEventHelper
    {
        public static void eventInsertNextCommandList(StardewValley.Event @event, List<GameEventCommand> commands)
        {
            List<String> commandStrList = new();

            foreach (var command in commands)
            {
                commandStrList.Add(command.getCommandString());
            }

            int index = @event.currentCommand + 1;
            List<string> list = ((IEnumerable<string>)@event.eventCommands).ToList<string>();
            if (index <= list.Count)
            {
                foreach (var command in commandStrList)
                {
                    list.Insert(index++, command);
                }
            }
            else
            {
                foreach (var command in commandStrList)
                {
                    list.Add(command);
                }
            }
            @event.eventCommands = list.ToArray();
        }
    }
}
