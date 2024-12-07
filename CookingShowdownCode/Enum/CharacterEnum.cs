using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Enum
{
    public enum CharacterEnum
    {
        Farmer,
        Lewis
    }

    public static class CharacterEnumExtensions
    {
        public static string GetName(this CharacterEnum character)
        {
            switch (character)
            {
                case CharacterEnum.Farmer:
                    return "farmer";
                case CharacterEnum.Lewis:
                    return "Lewis";
                default:
                    return "";
            }
        }
    }
}
