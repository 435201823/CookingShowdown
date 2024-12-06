using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class EndCmd : GameEventCommand
    {
        public string getCommandString()
        {
            return "end";
        }
    }
}
