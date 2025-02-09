using CookingShowdownCode.Helper;
using StardewValley;

namespace CookingShowdownCode.Limit
{
    internal class LimitIncludeVegetable : ILimit
    {
        public LimitDescriptionObj getLimitDescription()
        {
            return new LimitDescriptionObj("competition.limit_include_vegetable", null);
        }

        public bool isValid(Item? cookItem, List<ItemStack>? ingredients, int cookTime)
        {
            return ILimit.ingredientsIncludeCategory(cookItem, ingredients, StardewValley.Object.VegetableCategory);
        }
    }
}
