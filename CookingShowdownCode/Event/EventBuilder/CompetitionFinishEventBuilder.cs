using CookingShowdownCode.Enum;
using CookingShowdownCode.Event.Command;
using Netcode;
using StardewValley;
using StardewValley.GameData.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Event.EventBuilder
{
    internal class CompetitionFinishEventBuilder
    {
        private Item cookItem;

        public CompetitionFinishEventBuilder(Item cookItem)
        {
            this.cookItem = cookItem;
        }

        public StardewValley.Event Build()
        {
            var npcList = new List<NpcPosition>();

            npcList.Add(new NpcPosition(CharacterEnum.Farmer, 14, 15, DirectionEnum.Up));
            npcList.Add(new NpcPosition(CharacterEnum.Lewis, 14, 9, DirectionEnum.Down));

            GameEventScript script = new GameEventScript("continue", 14, 11, npcList);
            script.AddCommand(new BroadCastEventCmd());
            script.AddCommand(new SkippableCmd());
            script.AddCommand(new PauseCmd(1000));

            

            var recipesCookedTimes = Game1.player.recipesCooked[cookItem.ItemId];

            //var a = Game1.player.craftingRecipes;
            //int craftTimes;
            //a.TryGetValue(cookItem.Name,out craftTimes);

            script.AddCommand(new SpeakICmd(CharacterEnum.Lewis, "speach.finish.lewis1",new { CookItemName = cookItem.DisplayName, RecipesCookedTimes = recipesCookedTimes, Price = cookItem.salePrice(true) }));
            script.AddCommand(new EndCmd());

            var scriptStr = script.GenerateEventScript();

            Logger.Info(scriptStr);
            return new StardewValley.Event(scriptStr);
        }
    }
}
