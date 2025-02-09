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
    //第五次比赛，比赛的主题是，食材包含蔬菜的料理
    internal class CompetitionL5 : ICompetionLevel
    {
        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Maru, new DishTortilla(QualityEnum.Normal), 6);
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.Willy, new DishTortilla(QualityEnum.Normal), 7);
        }

        public RecipeSummary? getThird()
        {
            return CompetitionContext.npcCook(CharacterEnum.Haley, new DishBeanHotpot(QualityEnum.Normal, QualityEnum.Normal), 6);
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitIncludeVegetable();
        }
    }
}
