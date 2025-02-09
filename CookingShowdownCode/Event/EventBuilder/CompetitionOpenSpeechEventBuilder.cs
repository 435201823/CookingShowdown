
using CookingShowdownCode.Enum;
using CookingShowdownCode.Event.Command;
using CookingShowdownCode.Event.Level;
using Microsoft.Xna.Framework.Media;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.TerrainFeatures;
using StardewValley.Tools;

namespace CookingShowdownCode.Event.EventBuilder
{
    public class CompetitionOpenSpeechEventBuilder 
    {
        private const int viewportX = 14;
        private const int viewportY = 11;

        public StardewValley.Event Build()
        {
            var npcList = randomNpcList();

            GameEventScript script = new GameEventScript("continue", viewportX, viewportY, npcList);
            script.AddCommand(new BroadCastEventCmd());
            script.AddCommand(new SkippableCmd());
            script.AddCommand(new PauseCmd(1000));

            if (CompetitionContext.Instance.isFirstCompetition())
            {
                script.AddCommand(firstSpeech());
            }
            else
            {
                script.AddCommand(normalSpeech());
            }
            script.AddCommand(startCookAndEvaluation());
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
            characterEnums.Add(CharacterEnum.Marnie);
            characterEnums.Add(CharacterEnum.Pam);
            characterEnums.Add(CharacterEnum.Penny);
            characterEnums.Add(CharacterEnum.Pierre);
            characterEnums.Add(CharacterEnum.Robin);
            characterEnums.Add(CharacterEnum.Sam);
            characterEnums.Add(CharacterEnum.Shane);
            characterEnums.Add(CharacterEnum.Vincent);
            characterEnums.Add(CharacterEnum.Willy);

            if (CompetitionContext.Instance.getLevel() == CompetitionLevelEnum.LV8)
            {
                characterEnums.Add(CharacterEnum.Sandy);
            }
            if (CompetitionContext.Instance.getLevel() == CompetitionLevelEnum.LV9)
            {
                characterEnums.Add(CharacterEnum.Krobus);
                characterEnums.Add(CharacterEnum.Sandy);
            }
            if (CompetitionContext.Instance.getLevel() == CompetitionLevelEnum.LV11)
            {
                characterEnums.Add(CharacterEnum.Bouncer);
            }

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

        private List<GameEventCommand> firstSpeech()
        {
            var script = new List<GameEventCommand>();
            script.Add(new EmoteCmd(CharacterEnum.Farmer, EmoteEnum.QuestionMarkEmote));
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis1"));
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis2"));
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis3"));
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis4"));
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis5"));
            script.Add(new SpeakICmd(CharacterEnum.Gus, "speach.first.gus1"));
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "speach.first.lewis6"));

            CompetitionContext.setSeenFirstCompetition();

            return script;
        }

        private List<GameEventCommand> normalSpeech()
        {
            var script = new List<GameEventCommand>();
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "speach.normal.lewis1"));
            var level = CompetitionContext.Instance.getLevel();
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "competition.this_week_limit"));
            var limitDescription = ICompetionLevel.getLevel(level).getLimit().getLimitDescription();
            script.Add(new SpeakICmd(CharacterEnum.Lewis, limitDescription.key,limitDescription.tokens));
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "speach.normal.please_cook"));

            return script;
        }

        private List<GameEventCommand> startCookAndEvaluation()
        {
            var script = new List<GameEventCommand>();
            script.Add(new PauseCmd(500));
            script.Add(new ShowCompetitionKitchenCmd());
            script.Add(new GlobalFadeCmd());
            script.Add(ViewportCmd.viewPortBlack(viewportX, viewportY));
            script.Add(new GenerateEvaluationCmd());

            return script;
        }

        public List<GameEventCommand> notImpl()
        {
            var script = new List<GameEventCommand>();
            script.Add(new SpeakICmd(CharacterEnum.Lewis, "notimpl"));
            return script;
        }

        public static void onEventFinish()
        {
            Game1.currentLocation.objects.Clear();
        }
    }
}
