
using CookingShowdownCode.Enum;
using CookingShowdownCode.Event.Command;
using Microsoft.Xna.Framework.Media;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.TerrainFeatures;
using StardewValley.Tools;

namespace CookingShowdownCode.Event.EventBuilder
{
    public class CompetitionOpenSpeechEventBuilder
    {
        public StardewValley.Event Build()
        {
            var npcList = randomNpcList();

            GameEventScript script = new GameEventScript("continue", 14, 11, npcList);
            script.AddCommand(new BroadCastEventCmd());
            script.AddCommand(new SkippableCmd());
            script.AddCommand(new PauseCmd(1000));
            script.AddCommand(new EmoteCmd(CharacterEnum.Farmer, EmoteEnum.QuestionMarkEmote));
            script.AddCommand(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis1"));
            script.AddCommand(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis2"));
            script.AddCommand(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis3"));
            script.AddCommand(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis4"));
            script.AddCommand(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis5"));
            script.AddCommand(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis6"));
            script.AddCommand(new EndCmd());

            var scriptStr = script.GenerateEventScript();

            Logger.Info(scriptStr);
            return new StardewValley.Event(scriptStr);
        }

        private List<NpcPosition> randomNpcList()
        {
            var npcList = new List<NpcPosition>();

            npcList.Add(new NpcPosition(CharacterEnum.Farmer, 14, 15, DirectionEnum.Up));
            npcList.Add(new NpcPosition(CharacterEnum.Lewis, 14, 9, DirectionEnum.Down));

            List<CharacterEnum> characterEnums = new List<CharacterEnum>();
            characterEnums.Add(CharacterEnum.Abigail);
            characterEnums.Add(CharacterEnum.Alex);
            characterEnums.Add(CharacterEnum.Caroline);
            characterEnums.Add(CharacterEnum.Clint);
            characterEnums.Add(CharacterEnum.Demetrius);
            characterEnums.Add(CharacterEnum.Elliott);
            characterEnums.Add(CharacterEnum.Emily);
            characterEnums.Add(CharacterEnum.Evelyn);
            characterEnums.Add(CharacterEnum.George);
            characterEnums.Add(CharacterEnum.Gus);
            characterEnums.Add(CharacterEnum.Haley);
            characterEnums.Add(CharacterEnum.Harvey);
            characterEnums.Add(CharacterEnum.Jas);
            characterEnums.Add(CharacterEnum.Jodi);
            characterEnums.Add(CharacterEnum.Leah);
            characterEnums.Add(CharacterEnum.Linus);
            characterEnums.Add(CharacterEnum.Maru);
            characterEnums.Add(CharacterEnum.Pam);
            characterEnums.Add(CharacterEnum.Penny);
            characterEnums.Add(CharacterEnum.Pierre);
            characterEnums.Add(CharacterEnum.Robin);
            characterEnums.Add(CharacterEnum.Sam);
            characterEnums.Add(CharacterEnum.Shane);
            characterEnums.Add(CharacterEnum.Vincent);

            HashSet<String> set = new HashSet<String>();

            foreach (var character in characterEnums)
            {
                String unique = "";
                int area;
                int x;
                int y;
                do { 
                    //生成随机数
                    area = Game1.random.Next(0, 2);
                    x = Game1.random.Next(0, 5);
                    y = Game1.random.Next(0, 11);
                    unique = "" + area + ","+ x + "," + y;
                }while(set.Contains(unique));
                set.Add(unique);

                if (area == 0)
                {
                    npcList.Add(new NpcPosition(character, 3+x, 7+y, DirectionEnum.Right));
                } else
                {
                    npcList.Add(new NpcPosition(character, 23+x, 7+y, DirectionEnum.Left));
                }

            }

            return npcList;
        }
    }
}
