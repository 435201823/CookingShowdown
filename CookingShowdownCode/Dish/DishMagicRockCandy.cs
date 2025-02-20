using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    public class DishMagicRockCandy : IDish
    {
        public string getCookItemId()
        {
            return "279";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("279", Enum.QualityEnum.Normal, 1),
            };
        }
    }
}
