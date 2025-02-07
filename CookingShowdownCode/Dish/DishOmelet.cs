using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishOmelet : IDish
    {
        private QualityEnum eggQuality;
        private QualityEnum milkQuality;

        public DishOmelet(QualityEnum eggQuality, QualityEnum milkQuality)
        {
            this.eggQuality = eggQuality;
            this.milkQuality = milkQuality;
        }

        public string getCookItemId()
        {
            return "195";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("180", eggQuality, 1), // 鸡蛋ID为180
            new ItemStack("184", milkQuality, 1), // 牛奶ID为184
        };
        }
    }
}
