using CookingShowdownCode.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.Command
{
    public class SpeakICmd : GameEventCommand
    {
        public string npcId;
        public string i18nKey;
        public object? tokens;

        public SpeakICmd(CharacterEnum character, string i18nKey, object? tokens = null) : this(character.GetName(), i18nKey,tokens)
        {
        }

        public SpeakICmd(string npcId, string i18nKey, object? tokens = null)
        {
            this.npcId = npcId;
            this.i18nKey = i18nKey;
            this.tokens = tokens;
        }

        public string getCommandString()
        {
            return "speak " + npcId + " \"" + InnerTranslator.getTranslate(i18nKey, tokens) + "\"";
        }
    }
}
