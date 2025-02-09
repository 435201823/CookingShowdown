using CookingShowdownCode.Dish;
using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using CookingShowdownCode.Limit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Level
{
    internal class CompetitionL11 : ICompetionLevel
    {
        //第十一次比赛，比赛的主题是 售价200金以上的料理
        public RecipeSummary getFirst()
        {
            //Emily
            return CompetitionContext.npcCook(CharacterEnum.Emily, new DishBruschetta(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 5);
        }

        public RecipeSummary getSecond()
        {
            //Penny
            return CompetitionContext.npcCook(CharacterEnum.Penny, new DishSalmonDinner(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 4);
        }

        public RecipeSummary? getThird()
        {
            //Bouncer
            return CompetitionContext.npcCook(CharacterEnum.Bouncer, new DishCrabCakes(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 5);
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitCoin(200);
        }
    }
}
