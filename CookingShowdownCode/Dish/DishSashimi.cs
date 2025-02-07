using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishSashimi : IDish
    {
        private String fishId;
        private QualityEnum fishQuality;

        public DishSashimi(String fishId, QualityEnum fishQuality)
        {
            this.fishId = fishId;
            this.fishQuality = fishQuality;
        }

        public string getCookItemId()
        {
            return "227";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack(fishId, fishQuality, 1),
            };
        }
    }
}
