using CookingShowdownCode.Dish;
using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using CookingShowdownCode.Limit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Level
{
    //第六次比赛，比赛的主题是，食材包含牛奶的料理
    internal class CompetitionL6 : ICompetionLevel
    {
        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Willy, new DishChowder(QualityEnum.Normal, QualityEnum.Silver), 10);
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.Haley, new DishOmelet(QualityEnum.Normal, QualityEnum.Normal), 2);
        }

        public RecipeSummary? getThird()
        {
            return CompetitionContext.npcCook(CharacterEnum.Alex, new DishIceCream(QualityEnum.Normal, QualityEnum.Normal), 20);
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitIncludeMilk();
        }
    }
}
