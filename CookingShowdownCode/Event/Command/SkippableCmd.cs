using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class SkippableCmd : GameEventCommand
    {
        public string getCommandString()
        {
            return "skippable";
        }
    }
}
