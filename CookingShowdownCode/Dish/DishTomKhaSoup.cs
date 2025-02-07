using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishTomKhaSoup : IDish
    {
        private QualityEnum coconutQuality;
        private QualityEnum shrimpQuality;
        private QualityEnum commonMushroomQuality;

        public DishTomKhaSoup(QualityEnum coconutQuality, QualityEnum shrimpQuality, QualityEnum commonMushroomQuality)
        {
            this.coconutQuality = coconutQuality;
            this.shrimpQuality = shrimpQuality;
            this.commonMushroomQuality = commonMushroomQuality;
        }

        public string getCookItemId()
        {
            // 冬阴汤的ID是218
            return "218";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("88", coconutQuality, 1), // 椰子ID为88
            new ItemStack("720", shrimpQuality, 1), // 虾ID为720
            new ItemStack("404", commonMushroomQuality, 1), // 普通蘑菇ID为404
        };
        }
    }
}
