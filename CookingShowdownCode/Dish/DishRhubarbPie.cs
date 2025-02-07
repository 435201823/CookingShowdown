using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;

namespace CookingShowdownCode.Dish
{
    internal class DishRhubarbPie : IDish
    {
        private QualityEnum rhubarbQuality;
        private QualityEnum wheatFlourQuality;
        private QualityEnum sugarQuality;

        public DishRhubarbPie(QualityEnum rhubarbQuality, QualityEnum wheatFlourQuality, QualityEnum sugarQuality)
        {
            this.rhubarbQuality = rhubarbQuality;
            this.wheatFlourQuality = wheatFlourQuality;
            this.sugarQuality = sugarQuality;
        }

        public string getCookItemId()
        {
            // 大黄派的ID是222
            return "222";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
        {
            new ItemStack("222", rhubarbQuality, 1), // 大黄ID为222
            new ItemStack("246", wheatFlourQuality, 1), // 小麦粉ID为246
            new ItemStack("245", sugarQuality, 1), // 糖ID为245
        };
        }
    }
}
