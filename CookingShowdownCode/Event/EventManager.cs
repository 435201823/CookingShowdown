using CookingShowdownCode.Enum;
using CookingShowdownCode.Event.EventBuilder;
using CookingShowdownCode.Helper;
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
        public static bool debug = false;

        public static void triggerEvent(GameLocation newLocation)
        {
            int dayOfWeek = getDayOfWeek();
            int timeOfDay = getTimeOfDay();

            //if (Game1.player.eventsSeen.Contains("20241218001"))
            //{
            //    return;
            //}
            if (debug && newLocation.Name.Equals("Custom_SaloonSecondFloor"))
            {
                triggerCompetitionEvent(newLocation);
            }
            if (dayOfWeek == 0 && timeOfDay >=1200 && timeOfDay <= 1500 && newLocation.Name.Equals("Custom_SaloonSecondFloor"))// between 12:00 and 15:00 sunday 
            {
                triggerCompetitionEvent(newLocation);
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

        public static void triggerCompetitionEvent(GameLocation location)
        {
            CompetitionContext.Instance.CompetitionStart();

            StardewValley.Event speechEvent = new CompetitionOpenSpeechEventBuilder().Build();
            location.startEvent(speechEvent);

            //while (Game1.eventUp || Game1.eventOver)
            //{
            //    await Task.Delay(100);
            //    //Logger.Info(Game1.CurrentEvent.eventCommands[Game1.CurrentEvent.currentCommand]);
            //}

            //CookGameLocation.ActivateCompetitionKitchen();

            //await CompetitionContext.Instance.WaitForCook();

            //var finishEvent = new CompetitionFinishEventBuilder()
            //    .Build();
            //location.startEvent(finishEvent);
        }
    }
}
