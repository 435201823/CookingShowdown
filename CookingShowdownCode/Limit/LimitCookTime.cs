using CookingShowdownCode.Helper;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Limit
{
    internal class LimitCookTime : ILimit
    {
        public int cookTimes;
        public LimitCookTime(int cookTimes)
        {
            this.cookTimes = cookTimes;
        }

        public LimitDescriptionObj getLimitDescription()
        {
            return new LimitDescriptionObj("competition.limit_cook_times", new { cookTimes });
        }

        public bool isValid(Item? cookItem, List<ItemStack>? ingredients, int cookTime)
        {
            if (cookItem != null && cookTime >= this.cookTimes)
            {
                return true;
            }
            return false;
        }
    }
}
