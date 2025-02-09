using CookingShowdownCode.Helper;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Limit
{
    public interface ILimit
    {
        LimitDescriptionObj getLimitDescription();

        bool isValid(Item? cookItem, List<ItemStack>? ingredients, int cookTime);

        static bool ingredientsIncludeCategory(Item? cookItem, List<ItemStack>? ingredients, int category)
        {
            if (cookItem != null && ingredients != null && ingredients.Count > 0)
            {
                foreach (var ingredient in ingredients)
                {
                    Item item = ItemRegistry.Create(ingredient.itemId);
                    if (item.Category == category)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool ingredientsIncludeSomething(Item? cookItem, List<ItemStack>? ingredients, string itemId)
        {
            if (cookItem != null && ingredients != null && ingredients.Count > 0)
            {
                foreach (var ingredient in ingredients)
                {
                    if (ingredient.itemId == itemId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
