using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishTortilla : IDish
    {
        private QualityEnum cornQuality;

        public DishTortilla(QualityEnum cornQuality)
        {
            this.cornQuality = cornQuality;
        }

        public string getCookItemId()
        {
            return "229";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("270", cornQuality, 1),
            };
        }
    }
}
