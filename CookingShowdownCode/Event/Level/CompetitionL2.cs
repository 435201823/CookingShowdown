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
    //第二次比赛，比赛无限制，alex做出薄煎饼，小幅提升难度
    public class CompetitionL2 : ICompetionLevel
    {
        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Jas, new DishFriedEgg(QualityEnum.Silver), 3);
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.Vincent, new DishFriedEgg(QualityEnum.Normal), 2);
        }

        public RecipeSummary? getThird()
        {
            return CompetitionContext.npcCook(CharacterEnum.Alex, new DishTortilla(QualityEnum.Normal), 4);
        }
    }
}
