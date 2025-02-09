using CookingShowdownCode.Helper;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Limit
{
    internal class LimitIngredientsNum : ILimit
    {
        private int num;
        public LimitIngredientsNum(int num)
        {
            this.num = num;
        }

        public LimitDescriptionObj getLimitDescription()
        {
            return new LimitDescriptionObj("competition.limit_ingredients_num", new { num });
        }

        public bool isValid(Item? cookItem, List<ItemStack>? ingredients, int cookTime)
        {
            if (cookItem != null && ingredients != null && ingredients.Count >= num)
            {
                return true;
            }
            return false;
        }
    }
}
