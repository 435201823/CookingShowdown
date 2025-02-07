using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishFiddleheadRisotto : IDish
    {
        private QualityEnum oilQuality;
        private QualityEnum fiddleheadFernQuality;
        private QualityEnum garlicQuality;

        public DishFiddleheadRisotto(QualityEnum oilQuality, QualityEnum fiddleheadFernQuality, QualityEnum garlicQuality)
        {
            this.oilQuality = oilQuality;
            this.fiddleheadFernQuality = fiddleheadFernQuality;
            this.garlicQuality = garlicQuality;
        }

        public string getCookItemId()
        {
            // 蕨菜烩饭的ID是649
            return "649";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("247", oilQuality, 1), // 油ID为247
            new ItemStack("259", fiddleheadFernQuality, 1), // 蕨菜ID为259
            new ItemStack("248", garlicQuality, 1), // 大蒜ID为248
        };
        }
    }
}
