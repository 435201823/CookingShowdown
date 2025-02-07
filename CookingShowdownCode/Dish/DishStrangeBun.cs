using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishStrangeBun : IDish
    {
        private QualityEnum wheatFlourQuality;
        private QualityEnum periwinkleQuality;
        private QualityEnum voidMayonnaiseQuality;

        public DishStrangeBun(QualityEnum wheatFlourQuality, QualityEnum periwinkleQuality, QualityEnum voidMayonnaiseQuality)
        {
            this.wheatFlourQuality = wheatFlourQuality;
            this.periwinkleQuality = periwinkleQuality;
            this.voidMayonnaiseQuality = voidMayonnaiseQuality;
        }

        public string getCookItemId()
        {
            // 奇异包子的ID是203
            return "203";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("246", wheatFlourQuality, 1), // 小麦粉ID为246
                new ItemStack("722", periwinkleQuality, 1), // 海螺ID为722
                new ItemStack("308", voidMayonnaiseQuality, 1), // 虚空蛋黄酱ID为308
            };
        }
    }
}
