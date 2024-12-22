using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Enum
{
    public enum QualityEnum
    {
        Normal = 0,
        Silver = 1,
        Gold = 2,
        Iridium = 4
    }

    public static class QualityEnumExtensions
    {
        public static int getInt(this QualityEnum quality)
        {
            return (int)quality;
        }

        public static QualityEnum from(int value)
        {
            return (QualityEnum)value;
        }
    }
}
