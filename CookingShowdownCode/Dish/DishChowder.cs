using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishChowder : IDish
    {
        private QualityEnum milkQuality;
        private QualityEnum clamQuality;

        public DishChowder(QualityEnum milkQuality, QualityEnum clamQuality) 
        {
            this.milkQuality = milkQuality;
            this.clamQuality = clamQuality;
        }

        public string getCookItemId()
        {
            return "727";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("184", milkQuality, 1),
                new ItemStack("372", clamQuality, 1),
            };
        }
    }
}
