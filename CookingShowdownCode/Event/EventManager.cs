using CookingShowdownCode.Event.EventBuilder;
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
        public static async Task triggerEvent(GameLocation location)
        {
            int dayOfWeek = getDayOfWeek();
            int timeOfDay = getTimeOfDay();

            if (dayOfWeek == 0 && timeOfDay >=1200 && timeOfDay <= 1500 && location.Name.Equals("Custom_SaloonSecondFloor"))// between 12:00 and 15:00 sunday 
            {

                await triggerCompetitionEvent(location);
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
            var speechEvent = new CompetitionOpenSpeechEventBuilder().Build();
            location.startEvent(speechEvent);

            while (Game1.eventUp || Game1.eventOver)
            {
                await Task.Delay(100);
            }

            CookGameLocation.ActivateCompetitionKitchen();
        }
    }
}
