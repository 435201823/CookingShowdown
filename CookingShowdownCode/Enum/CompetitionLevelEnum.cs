using CookingShowdownCode.Event;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Enum
{
    public enum CompetitionLevelEnum
    {
        LV1,//0
        LV2,//1
        LV3,
        LV4,
        LV5,
        LV6,
        LV7,
        LV8,
        LV9,
        LV10,
        LV11,
        LV12,
        LV13,
        LV14,
        LV15,
        LV16
    }

    public static class CompetitionLevelEnumExtensions
    {
        public static string eventPrefix = "202412191635";

        public static string firstEvent = eventPrefix + "000";

        //转换为事件id
        public static String ToEventIdString(this CompetitionLevelEnum levelEnum)
        {
            return eventPrefix + levelEnum.ToNumber();
        }

        public static String ToNumber(this CompetitionLevelEnum levelEnum)
        {
            int level = (int)levelEnum + 1;
            if (level >= 10)
            {
                return "0" + level;
            } else
            {
                return "00" + level;
            }
        }

        public static CompetitionLevelEnum from(String number)
        {
            return (CompetitionLevelEnum)(int.Parse(number));
        }

        public static CompetitionLevelEnum from(int number)
        {
            return (CompetitionLevelEnum)(number);
        }
    }
}
