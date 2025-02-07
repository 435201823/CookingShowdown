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
    //第四次比赛，比赛的主题是，食材包含鱼的料理
    internal class CompetitionL4 : ICompetionLevel
    {
        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Alex, new DishSashimi("136", QualityEnum.Normal), 6);
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.Maru, new DishSashimi("136", QualityEnum.Normal), 6);
        }

        public RecipeSummary? getThird()
        {
            return CompetitionContext.npcCook(CharacterEnum.Willy, new DishTroutSoup(QualityEnum.Normal, QualityEnum.Normal), 6);
        }
    }
}
