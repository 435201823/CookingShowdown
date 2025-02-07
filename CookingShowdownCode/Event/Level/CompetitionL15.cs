using CookingShowdownCode.Dish;
using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Level
{
    internal class CompetitionL15 : ICompetionLevel
    {
        //第十五次比赛，制作次数超过50次的料理
        public RecipeSummary getFirst()
        {
            //Caroline
            return CompetitionContext.npcCook(CharacterEnum.Caroline, new DishCompleteBreakfast(QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver), 50);
        }

        public RecipeSummary getSecond()
        {
            //Jodi
            return CompetitionContext.npcCook(CharacterEnum.Jodi, new DishFiddleheadRisotto(QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver), 50);
        }

        public RecipeSummary? getThird()
        {
            //Evelyn
            return CompetitionContext.npcCook(CharacterEnum.Evelyn, new DishPumpkinPie(QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver), 60);
        }
    }
}
