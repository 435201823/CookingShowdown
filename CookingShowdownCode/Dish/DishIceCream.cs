using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishIceCream : IDish
    {
        private QualityEnum milkQuality;
        private QualityEnum sugarQuality;

        public DishIceCream(QualityEnum milkQuality, QualityEnum sugarQuality)
        {
            this.milkQuality = milkQuality;
            this.sugarQuality = sugarQuality;
        }

        public string getCookItemId()
        {
            return "233";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("232", milkQuality, 1),
                new ItemStack("184", sugarQuality, 1),
            };
        }
    }
}
