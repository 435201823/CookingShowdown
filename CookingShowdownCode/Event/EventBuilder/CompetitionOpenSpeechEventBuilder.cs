
using CookingShowdownCode.Enum;
using CookingShowdownCode.Event.Command;
using StardewValley;

namespace CookingShowdownCode.Event.EventBuilder
{
    public class CompetitionOpenSpeechEventBuilder
    {
        public CompetitionOpenSpeechEventBuilder()
        {

        }

        public StardewValley.Event Build()
        {
            var npcList = new List<NpcPosition>();

            npcList.Add(new NpcPosition(CharacterEnum.Farmer, 14, 15,DirectionEnum.Up));
            npcList.Add(new NpcPosition(CharacterEnum.Lewis, 14, 9,DirectionEnum.Down));

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
    }
}
