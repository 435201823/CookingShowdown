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
            if (CompetitionContext.todayHasSeenEvent())
            {
                return;
            }
            CompetitionContext.clearAndInit();
            CompetitionContext.Instance.CompetitionStart();

            StardewValley.Event speechEvent = new CompetitionOpenSpeechEventBuilder().Build();
            speechEvent.onEventFinished += CompetitionOpenSpeechEventBuilder.onEventFinish;
            location.startEvent(speechEvent);
        }
    }
}
