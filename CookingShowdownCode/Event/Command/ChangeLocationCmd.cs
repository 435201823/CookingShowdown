using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class ChangeLocationCmd : GameEventCommand
    {
        private string location;

        public ChangeLocationCmd(string location)
        {
            this.location = location;
        }

        public string getCommandString()
        {
            return "changeLocation " + location;
        }
    }
}
