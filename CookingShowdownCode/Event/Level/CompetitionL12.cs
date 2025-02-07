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
    internal class CompetitionL12 : ICompetionLevel
    {
        //第十二次比赛，比赛的主题是 需要三个以上材料的料理
        public RecipeSummary getFirst()
        {
            //Emily
            return CompetitionContext.npcCook(CharacterEnum.Emily, new DishBruschetta(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 6);
        }

        public RecipeSummary getSecond()
        {
            //Penny
            return CompetitionContext.npcCook(CharacterEnum.Penny, new DishSalmonDinner(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 5);
        }

        public RecipeSummary? getThird()
        {
            //Marnie
            return CompetitionContext.npcCook(CharacterEnum.Marnie, new DishRhubarbPie(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 5);
        }
    }
}
