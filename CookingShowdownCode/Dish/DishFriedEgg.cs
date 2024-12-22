using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    public class DishFriedEgg : IDish
    {
        private QualityEnum eggQuality;

        public DishFriedEgg(QualityEnum eggQuality)
        {
            this.eggQuality = eggQuality;
        }

        public string getCookItemId()
        {
            return "194";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("180", eggQuality, 1),
            };
        }
    }
}
