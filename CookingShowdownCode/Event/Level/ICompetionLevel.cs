using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Level
{
    internal interface ICompetionLevel
    {
        public RecipeSummary getFirst();
        public RecipeSummary getSecond();
        public RecipeSummary? getThird();

        public List<RecipeSummary> getThreeCompetitionDish()
        {
            var third = getThird();
            if (third == null)
            {
                return new List<RecipeSummary>() { getFirst(), getSecond() };
            }
            else
            {
                return new List<RecipeSummary>() { getFirst(), getSecond(), third };
            }
        }

        public static ICompetionLevel getLevel(CompetitionLevelEnum levelEnum)
        {
            switch (levelEnum)
            {
                case CompetitionLevelEnum.LV1:
                    return new CompetitionL1();
                case CompetitionLevelEnum.LV2:
                    return new CompetitionL2();
                case CompetitionLevelEnum.LV3:
                    return new CompetitionL3();
                case CompetitionLevelEnum.LV4:
                    return new CompetitionL4();
                case CompetitionLevelEnum.LV5:
                    return new CompetitionL5();
                case CompetitionLevelEnum.LV6:
                    return new CompetitionL6();
                case CompetitionLevelEnum.LV7:
                    return new CompetitionL7();
                case CompetitionLevelEnum.LV8:
                    return new CompetitionL8();
                case CompetitionLevelEnum.LV9:
                    return new CompetitionL9();
                case CompetitionLevelEnum.LV10:
                    return new CompetitionL10();
                case CompetitionLevelEnum.LV11:
                    return new CompetitionL11();
                case CompetitionLevelEnum.LV12:
                    return new CompetitionL12();
                case CompetitionLevelEnum.LV13:
                    return new CompetitionL13();
                case CompetitionLevelEnum.LV14:
                    return new CompetitionL14();
                case CompetitionLevelEnum.LV15:
                    return new CompetitionL15();
                case CompetitionLevelEnum.LV16:
                    return new CompetitionL16();
                default:
                    throw new NotImplementedException("指定的竞赛级别未实现。");
            }
        }
    }
}
