﻿using CookingShowdownCode.Dish;
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
    internal class CompetitionL16 : ICompetionLevel
    {
        //第十六次比赛，拿出你最强的料理
        public RecipeSummary getFirst()
        {
            //Jodi
            return CompetitionContext.npcCook(CharacterEnum.Jodi, new DishFiddleheadRisotto(QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver), 50);
        }

        public RecipeSummary getSecond()
        {
            //Evelyn
            return CompetitionContext.npcCook(CharacterEnum.Evelyn, new DishPumpkinPie(QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver, QualityEnum.Silver), 60);
        }

        public RecipeSummary? getThird()
        {
            //Wizard
            var summary = CompetitionContext.npcCook(CharacterEnum.Wizard, new DishMagicRockCandy(), 100);
            summary.totalScore = 2000;
            return summary;
        }

        ILimit ICompetionLevel.getLimit()
        {
            return new LimitNone();
        }
    }
}
