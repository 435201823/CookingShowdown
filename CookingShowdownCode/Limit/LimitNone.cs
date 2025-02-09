using CookingShowdownCode.Helper;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Limit
{
    internal class LimitNone : ILimit
    {
        public LimitDescriptionObj getLimitDescription()
        {
            return new LimitDescriptionObj("competition.limit_none", null);
        }

        public bool isValid(Item? cookItem, List<ItemStack>? ingredients, int cookTime)
        {
            if (cookItem != null && ingredients != null && ingredients.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
