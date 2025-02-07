using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishPumpkinPie : IDish
    {
        private QualityEnum pumpkinQuality;
        private QualityEnum wheatFlourQuality;
        private QualityEnum milkQuality;
        private QualityEnum sugarQuality;

        public DishPumpkinPie(QualityEnum pumpkinQuality, QualityEnum wheatFlourQuality, QualityEnum milkQuality, QualityEnum sugarQuality)
        {
            this.pumpkinQuality = pumpkinQuality;
            this.wheatFlourQuality = wheatFlourQuality;
            this.milkQuality = milkQuality;
            this.sugarQuality = sugarQuality;
        }

        public string getCookItemId()
        {
            // 南瓜派的ID是608
            return "608";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("276", pumpkinQuality, 1), // 南瓜ID为276
            new ItemStack("246", wheatFlourQuality, 1), // 小麦粉ID为246
            new ItemStack("436", milkQuality, 1), // 牛奶ID为436
            new ItemStack("245", sugarQuality, 1), // 糖ID为245
        };
        }
    }
}
