using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishSpicyEel : IDish
    {
        private QualityEnum eelQuality;
        private QualityEnum hotPepperQuality;

        public DishSpicyEel(QualityEnum eelQuality, QualityEnum hotPepperQuality)
        {
            this.eelQuality = eelQuality;
            this.hotPepperQuality = hotPepperQuality;
        }

        public string getCookItemId()
        {
            // 辣鳗鱼的ID是266
            return "226";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("148", eelQuality, 1), // 鳗鱼ID为148
            new ItemStack("260", hotPepperQuality, 1), // 辣椒ID为260
        };
        }
    }
}
