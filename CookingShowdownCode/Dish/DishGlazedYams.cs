using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishGlazedYams : IDish
    {
        private QualityEnum yamQuality;
        private QualityEnum sugarQuality;

        public DishGlazedYams(QualityEnum yamQuality, QualityEnum sugarQuality)
        {
            this.yamQuality = yamQuality;
            this.sugarQuality = sugarQuality;
        }

        public string getCookItemId()
        {
            return "208";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("280", yamQuality, 1), // 山药ID为208
            new ItemStack("245", sugarQuality, 1), // 糖ID为245
        };
        }
    }
}
