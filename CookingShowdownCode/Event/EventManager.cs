using CookingShowdownCode.Enum;
using CookingShowdownCode.Event.EventBuilder;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTile.Dimensions;

namespace CookingShowdownCode.Event
{
    public class EventManager
    {
        public static async Task triggerEvent(GameLocation newLocation, GameLocation oldLocation)
        {
            int dayOfWeek = getDayOfWeek();
            int timeOfDay = getTimeOfDay();

            if (dayOfWeek == 0 && timeOfDay >=1200 && timeOfDay <= 1500 && newLocation.Name.Equals("Custom_SaloonSecondFloor") && oldLocation.Name.Equals("Saloon"))// between 12:00 and 15:00 sunday 
            {
                await triggerCompetitionEvent(newLocation);
            }
        }

        
        // Get the day of the week，0 is Sunday，1-6 is Monday-Saturday
        public static int getDayOfWeek()
        {
            return Game1.dayOfMonth % 7;
        }

        public static int getTimeOfDay()
        {
            return Game1.timeOfDay;
        }

        public static async Task triggerCompetitionEvent(GameLocation location)
        {
            CompetitionContext.Instance.CompetitionStart();

            var speechEvent = new CompetitionOpenSpeechEventBuilder().Build();
            location.startEvent(speechEvent);

            while (Game1.eventUp || Game1.eventOver)
            {
                await Task.Delay(100);
                //Logger.Info(Game1.CurrentEvent.eventCommands[Game1.CurrentEvent.currentCommand]);
            }

            CookGameLocation.ActivateCompetitionKitchen();

            await CompetitionContext.Instance.WaitForCook();

            Item? cookItem = CompetitionContext.Instance.getCookItem();
            if (cookItem == null)
            {
                return;
            }

            var finishEvent = new CompetitionFinishEventBuilder(cookItem).Build();
            location.startEvent(finishEvent);
        }
    }
}
