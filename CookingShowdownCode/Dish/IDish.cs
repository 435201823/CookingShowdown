using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    public interface IDish
    {
        string getCookItemId();
        List<ItemStack> getIngredients();
    }
}
