using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class ShowCompetitionKitchenCmd : GameEventCommand
    {
        public string getCommandString()
        {
            return "showCompetitionKitchen";
        }

        public static async void ShowCompetitionKitchen(StardewValley.Event @event, string[] args, EventContext context)
        {
            if (!CompetitionContext.Instance.blockMenu())
            {
                return;
            }

            try
            {
                CookGameLocation.ActivateCompetitionKitchen();
                await CompetitionContext.Instance.WaitForCook();
                ++@event.currentCommand;
            }
            finally
            {
                CompetitionContext.Instance.unblockMenu();
            }
        }
    }
}
