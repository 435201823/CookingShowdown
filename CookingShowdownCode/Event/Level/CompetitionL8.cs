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
    internal class CompetitionL8 : ICompetionLevel
    {
        //第八次比赛，比赛的主题是随意发挥
        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Abigail, new DishRootsPlatter(QualityEnum.Silver, QualityEnum.Normal), 11);
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.George, new DishSpicyEel(QualityEnum.Silver, QualityEnum.Normal), 10);
        }

        public RecipeSummary? getThird()
        {
            return CompetitionContext.npcCook(CharacterEnum.Sandy, new DishTomKhaSoup(QualityEnum.Silver, QualityEnum.Normal, QualityEnum.Normal), 10);
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitNone();
        }
    }
}
