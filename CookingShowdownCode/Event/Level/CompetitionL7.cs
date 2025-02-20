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
    //第七次比赛，比赛的主题是，提供增益效果的料理
    internal class CompetitionL7 : ICompetionLevel
    {

        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Haley, new DishBeanHotpot(QualityEnum.Normal, QualityEnum.Normal), 7);
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.Abigail, new DishRootsPlatter(QualityEnum.Silver, QualityEnum.Normal), 10);
        }

        public RecipeSummary? getThird()
        {
            return CompetitionContext.npcCook(CharacterEnum.George, new DishSpicyEel(QualityEnum.Silver, QualityEnum.Silver), 15);
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitNeedBuff();
        }
    }
}
