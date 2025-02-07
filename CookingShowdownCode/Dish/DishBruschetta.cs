using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;

namespace CookingShowdownCode.Dish
{
    internal class DishBruschetta : IDish
    {
        private QualityEnum breadQuality;
        private QualityEnum oilQuality;
        private QualityEnum tomatoQuality;

        public DishBruschetta(QualityEnum breadQuality, QualityEnum oilQuality, QualityEnum tomatoQuality)
        {
            this.breadQuality = breadQuality;
            this.oilQuality = oilQuality;
            this.tomatoQuality = tomatoQuality;
        }

        public string getCookItemId()
        {
            // 意式烤面包的ID是618
            return "618";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("216", breadQuality, 1), // 面包ID为216
            new ItemStack("247", oilQuality, 1), // 油ID为247
            new ItemStack("256", tomatoQuality, 1), // 番茄ID为256
        };
        }
    }
}
