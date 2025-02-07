using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishCompleteBreakfast : IDish
    {
        private QualityEnum friedEggQuality;
        private QualityEnum milkQuality;
        private QualityEnum hashbrownsQuality;
        private QualityEnum pancakesQuality;

        public DishCompleteBreakfast(QualityEnum friedEggQuality, QualityEnum milkQuality, QualityEnum hashbrownsQuality, QualityEnum pancakesQuality)
        {
            this.friedEggQuality = friedEggQuality;
            this.milkQuality = milkQuality;
            this.hashbrownsQuality = hashbrownsQuality;
            this.pancakesQuality = pancakesQuality;
        }

        public string getCookItemId()
        {
            // 完整早餐的ID是201
            return "201";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("194", friedEggQuality, 1), // 煎蛋ID为194
            new ItemStack("184", milkQuality, 1), // 牛奶ID为184
            new ItemStack("210", hashbrownsQuality, 1), // 土豆饼ID为210
            new ItemStack("211", pancakesQuality, 1), // 煎饼ID为211
        };
        }
    }
}
