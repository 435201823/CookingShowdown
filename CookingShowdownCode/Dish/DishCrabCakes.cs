using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishCrabCakes : IDish
    {
        private QualityEnum crabQuality;
        private QualityEnum wheatFlourQuality;
        private QualityEnum eggQuality;
        private QualityEnum oilQuality;

        public DishCrabCakes(QualityEnum crabQuality, QualityEnum wheatFlourQuality, QualityEnum eggQuality, QualityEnum oilQuality)
        {
            this.crabQuality = crabQuality;
            this.wheatFlourQuality = wheatFlourQuality;
            this.eggQuality = eggQuality;
            this.oilQuality = oilQuality;
        }

        public string getCookItemId()
        {
            // 蟹饼的ID是732
            return "732";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("717", crabQuality, 1), // 螃蟹ID为717
            new ItemStack("246", wheatFlourQuality, 1), // 小麦粉ID为246
            new ItemStack("180", eggQuality, 1), // 鸡蛋ID为180
            new ItemStack("247", oilQuality, 1), // 油ID为247
        };
        }
    }
}
