using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class FadeCmd : GameEventCommand
    {
        private bool? unfade;

        public FadeCmd(bool unfade)
        {
            this.unfade = unfade;
        }

        public string getCommandString()
        {
            if (unfade == null)
            {
                return "fade";
            }
            return $"fade {unfade}";
        }
    }
}
