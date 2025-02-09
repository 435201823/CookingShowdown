using CookingShowdownCode.Helper;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Limit
{
    internal class LimitIncludeMilk : ILimit
    {
        public LimitDescriptionObj getLimitDescription()
        {
            return new LimitDescriptionObj("competition.limit_include_milk", null);
        }

        public bool isValid(Item? cookItem, List<ItemStack>? ingredients, int cookTime)
        {
            return ILimit.ingredientsIncludeCategory(cookItem, ingredients, StardewValley.Object.MilkCategory);
        }
    }
}
