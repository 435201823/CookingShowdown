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
    //第一次比赛，没有限制比赛条件
    public class CompetitionL1 : ICompetionLevel
    {
        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Jas, new DishFriedEgg(QualityEnum.Silver), 2);
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.Vincent, new DishFriedEgg(QualityEnum.Normal), 1);
        }

        public RecipeSummary? getThird()
        {
            return null;
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitNone();
        }
    }
}
