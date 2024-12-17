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
        Abigail,
        Alex,
        Caroline,
        Clint,
        Demetrius,
        Elliott,
        Emily,
        Evelyn,
        Fizz,
        George,
        Gus,
        Haley,
        Harvey,
        Jas,
        Jodi,
        Kent,
        Krobus,
        Leah,
        Lewis,
        Linus,
        Marcello,
        Marlon,
        Marnie,
        Maru,
        Morris,
        MrQi,
        Pam,
        Penny,
        Pierre,
        Robin,
        Sam,
        Sandy,
        Shane,
        Vincent,
        Willy,
        Wizard
    }

    public static class CharacterEnumExtensions
    {
        public static string GetName(this CharacterEnum character)
        {
            switch (character)
            {
                case CharacterEnum.Farmer:
                    return "farmer";
                default:
                    return character.ToString();
            }
        }
    }
}
