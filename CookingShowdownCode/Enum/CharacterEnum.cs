using StardewValley;
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
        Bouncer,
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

        public static CharacterEnum from(String name)
        {
            switch (name)
            {
                case "farmer":
                    return CharacterEnum.Farmer;
                default:
                    return (CharacterEnum)System.Enum.Parse(typeof(CharacterEnum), name);
            }
        }

        public static string GetDisplayName(this CharacterEnum character)
        {
            if (character == CharacterEnum.Farmer)
            {
                return Game1.player.displayName;
            }

            Game1.characterData.TryGetValue(character.GetName(), out var displayName);

            if (displayName == null || displayName.DisplayName == null)
            {
                return "(can not find character display name)";
            }
            return displayName.DisplayName;
        }
    }
}
