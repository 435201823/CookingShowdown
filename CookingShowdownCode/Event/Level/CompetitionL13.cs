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
    internal class CompetitionL13 : ICompetionLevel
    {
        //第十三次比赛，比赛的主题是 售价300金以上的料理
        public RecipeSummary getFirst()
        {
            //Penny
            return CompetitionContext.npcCook(CharacterEnum.Penny, new DishSalmonDinner(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 5);
        }

        public RecipeSummary getSecond()
        {
            //Marnie
            return CompetitionContext.npcCook(CharacterEnum.Marnie, new DishRhubarbPie(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 5);
        }

        public RecipeSummary? getThird()
        {
            //Caroline
            return CompetitionContext.npcCook(CharacterEnum.Caroline, new DishCompleteBreakfast(QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver), 25);

        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitCoin(300);
        }
    }
}
