using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishPancakes : IDish
    {
        private QualityEnum wheatFlourQuality;
        private QualityEnum eggQuality;

        public DishPancakes(QualityEnum wheatFlourQuality, QualityEnum eggQuality)
        {
            this.wheatFlourQuality = wheatFlourQuality;
            this.eggQuality = eggQuality;
        }

        public string getCookItemId()
        {
            return "211";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("246", wheatFlourQuality, 1),
                new ItemStack("180", eggQuality, 1),
            };
        }
    }
}
