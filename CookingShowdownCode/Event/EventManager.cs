using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event
{
    public class EventManager
    {
        public static void triggerEvent(GameLocation location)
        {
            int dayOfWeek = getDayOfWeek();
            int timeOfDay = getTimeOfDay();

            if (dayOfWeek == 0 && timeOfDay >=1200 && timeOfDay <= 1500)// between 12:00 and 15:00 sunday 
            {
                
                location.startEvent();
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
    }
}
