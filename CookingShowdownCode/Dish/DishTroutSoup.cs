using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    public class DishTroutSoup : IDish
    {
        private QualityEnum rainbowTroutQuality;
        private QualityEnum greenAlgaeQuality;

        public DishTroutSoup(QualityEnum rainbowTroutQuality, QualityEnum greenAlgaeQuality)
        {
            this.rainbowTroutQuality = rainbowTroutQuality;
            this.greenAlgaeQuality = greenAlgaeQuality;
        }

        public string getCookItemId()
        {
            return "219";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("138", rainbowTroutQuality, 1),
                new ItemStack("153", greenAlgaeQuality, 1),
            };
        }
    }
}
