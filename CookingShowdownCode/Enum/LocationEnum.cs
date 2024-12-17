using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Enum
{
    public enum LocationEnum
    {
        CustomSaloonSecondFloorKitchen
    }

    public static class LocationEnumExtensions
    {
        public static string GetName(this LocationEnum location)
        {
            switch (location)
            {
                case LocationEnum.CustomSaloonSecondFloorKitchen:
                    return "Custom_SaloonSecondFloor_Kitchen";
                default:
                    return location.ToString();
            }
        }
    }
}
