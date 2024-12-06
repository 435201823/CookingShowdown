﻿using CookingShowdownCode.Enum;
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

        public SpeakICmd(CharacterEnum character, string i18nKey):this(character.GetName(), i18nKey)
        {

        }

        public SpeakICmd(string npcId, string i18nKey)
        {
            this.npcId = npcId;
            this.i18nKey = i18nKey;
        }

        public string getCommandString()
        {
            return "speak " + npcId + " \"" + InnerTranslator.getTranslate(i18nKey) + "\"";
        }
    }
}
