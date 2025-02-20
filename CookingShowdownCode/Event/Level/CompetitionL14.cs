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
    internal class CompetitionL14 : ICompetionLevel
    {

        //第十四次比赛，比赛的主题是 350金以上的料理
        public RecipeSummary getFirst()
        {
            //Marnie
            return CompetitionContext.npcCook(CharacterEnum.Marnie, new DishRhubarbPie(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 5);
        }

        public RecipeSummary getSecond()
        {
            //Caroline
            return CompetitionContext.npcCook(CharacterEnum.Caroline, new DishCompleteBreakfast(QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver), 25);
        }

        public RecipeSummary? getThird()
        {
            //Jodi
            return CompetitionContext.npcCook(CharacterEnum.Jodi, new DishFiddleheadRisotto(QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver), 35);
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitCoin(350);
        }
    }
}
