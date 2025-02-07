using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishTropicalCurry : IDish
    {
        private QualityEnum coconutQuality;
        private QualityEnum pineappleQuality;
        private QualityEnum hotPepperQuality;

        public DishTropicalCurry(QualityEnum coconutQuality, QualityEnum pineappleQuality, QualityEnum hotPepperQuality)
        {
            this.coconutQuality = coconutQuality;
            this.pineappleQuality = pineappleQuality;
            this.hotPepperQuality = hotPepperQuality;
        }

        public string getCookItemId()
        {
            // 热带咖喱的ID是907
            return "907";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("88", coconutQuality, 1), // 椰子ID为88
            new ItemStack("832", pineappleQuality, 1), // 菠萝ID为832
            new ItemStack("260", hotPepperQuality, 1), // 辣椒ID为260
        };
        }
    }
}
