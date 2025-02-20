using CookingShowdownCode.Dish;
using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using CookingShowdownCode.Limit;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Level
{
    internal class CompetitionL9 : ICompetionLevel
    {

        //第九次比赛，食材包含鸡蛋的料理
        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Abigail, new DishOmelet(QualityEnum.Normal, QualityEnum.Normal), 10);
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.Sandy, new DishOmelet(QualityEnum.Normal, QualityEnum.Normal), 12);
        }

        public RecipeSummary? getThird()
        {
            return CompetitionContext.npcCook(CharacterEnum.Krobus, new DishStrangeBun(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Gold), 10);
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitIncludeEgg();
        }
    }
}
