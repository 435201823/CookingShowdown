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
    //第三次比赛，比赛的主题是至少使用两种食材的料理
    internal class CompetitionL3 : ICompetionLevel
    {

        public RecipeSummary getFirst()
        {
            return CompetitionContext.npcCook(CharacterEnum.Jas, new DishPancakes(QualityEnum.Normal, QualityEnum.Normal), 3);
            
        }

        public RecipeSummary getSecond()
        {
            return CompetitionContext.npcCook(CharacterEnum.Alex, new DishPancakes(QualityEnum.Normal, QualityEnum.Normal), 6);
        }

        public RecipeSummary? getThird()
        {
            return CompetitionContext.npcCook(CharacterEnum.Maru, new DishRootsPlatter(QualityEnum.Normal, QualityEnum.Normal), 6);
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitIngredientsNum(2);
        }
    }
}
