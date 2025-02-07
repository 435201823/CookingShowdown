using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StardewValley.Minigames.BoatJourney;

namespace CookingShowdownCode.Dish
{
    internal class DishRootsPlatter : IDish
    {
        private QualityEnum CaveCarrotQuality;
        private QualityEnum WinterRootQuality;

        public DishRootsPlatter(QualityEnum CaveCarrotQuality, QualityEnum WinterRootQuality)
        {
            this.CaveCarrotQuality = CaveCarrotQuality;
            this.WinterRootQuality = WinterRootQuality;
        }

        public string getCookItemId()
        {
            return "244";
        }

        public List<ItemStack> getIngredients()
        {
            return new List<ItemStack>()
            {
                new ItemStack("78", CaveCarrotQuality, 1),
                new ItemStack("412", WinterRootQuality, 1),
            };
        }
    }
}
