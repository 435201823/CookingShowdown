using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishCranberryCandy : IDish
    {
        private QualityEnum cranberriesQuality;
        private QualityEnum appleQuality;
        private QualityEnum sugarQuality;

        public DishCranberryCandy(QualityEnum cranberriesQuality, QualityEnum appleQuality, QualityEnum sugarQuality)
        {
            this.cranberriesQuality = cranberriesQuality;
            this.appleQuality = appleQuality;
            this.sugarQuality = sugarQuality;
        }

        public string getCookItemId()
        {
            return "612";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("282", cranberriesQuality, 1), // 蔓越莓ID为282
            new ItemStack("613", appleQuality, 1), // 苹果ID为613
            new ItemStack("245", sugarQuality, 1), // 糖ID为245
        };
        }
    }
}
