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
    internal class CompetitionL10 : ICompetionLevel
    {
        //第十次比赛，比赛的主题是 食材包含糖的料理
        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Alex, new DishIceCream(QualityEnum.Normal, QualityEnum.Normal), 20);
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.Emily, new DishCranberryCandy(QualityEnum.Normal, QualityEnum.Normal, QualityEnum.Normal), 20);
        }

        public RecipeSummary? getThird()
        {
            return CompetitionContext.npcCook(CharacterEnum.Penny, new DishGlazedYams(QualityEnum.Normal, QualityEnum.Normal), 20);
        }
    }
}
