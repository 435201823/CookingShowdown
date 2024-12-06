using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class PauseCmd : GameEventCommand
    {
        private int time;
        public PauseCmd(int time)
        {
            this.time = time;
        }

        public string getCommandString()
        {
            return "pause " + time;
        }
    }
}
