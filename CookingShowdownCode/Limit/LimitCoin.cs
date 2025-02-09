using CookingShowdownCode.Helper;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Limit
{
    internal class LimitCoin : ILimit
    {
        private int coinNum;
        public LimitCoin(int coinNum) 
        {
            this.coinNum = coinNum;
        }

        public LimitDescriptionObj getLimitDescription()
        {
            return new LimitDescriptionObj("competition.limit_coin", new { price = coinNum });
        }

        public bool isValid(Item? cookItem, List<ItemStack>? ingredients, int cookTime)
        {
            if (cookItem != null && cookItem.salePrice() >= coinNum)
            {
                return true;
            }
            return false;
        }
    }
}
