using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Dish
{
    internal class DishSalmonDinner : IDish
    {
        private QualityEnum salmonQuality;
        private QualityEnum amaranthQuality;
        private QualityEnum kaleQuality;

        public DishSalmonDinner(QualityEnum salmonQuality, QualityEnum amaranthQuality, QualityEnum kaleQuality)
        {
            this.salmonQuality = salmonQuality;
            this.amaranthQuality = amaranthQuality;
            this.kaleQuality = kaleQuality;
        }

        public string getCookItemId()
        {
            // 鲑鱼晚餐的ID是212
            return "212";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("139", salmonQuality, 1), // 鲑鱼ID为139
            new ItemStack("300", amaranthQuality, 1), // 苋菜ID为300
            new ItemStack("250", kaleQuality, 1), // 羽衣甘蓝ID为250
        };
        }
    }
}
