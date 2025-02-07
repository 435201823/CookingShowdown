using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    public class DishBeanHotpot : IDish
    {
        private QualityEnum bean1Quality;
        private QualityEnum bean2Quality;

        public DishBeanHotpot(QualityEnum bean1Quality, QualityEnum bean2Quality)
        {
            this.bean1Quality = bean1Quality;
            this.bean2Quality = bean2Quality;
        }

        public string getCookItemId()
        {
            return "207";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("188", bean1Quality, 1),
                new ItemStack("188", bean2Quality, 1),
            };
        }
    }
}
