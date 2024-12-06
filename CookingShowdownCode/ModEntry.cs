using CookingShowdownCode.Event;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace CookingShowdownCode
{
    internal sealed class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            this.Monitor.Log("模组启动啦");

            //init i18n
            InnerTranslator.init(this.Helper.Translation);

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.Player.Warped += this.OnWarped;
            helper.Events.Display.MenuChanged += this.OnMenuChanged;
        }

        private void OnMenuChanged(object? sender, MenuChangedEventArgs e)
        {
            var a = e.NewMenu?.GetType();
            this.Monitor.Log("menu:" + a?.ToString(), LogLevel.Debug);
            
        }

        private void OnWarped(object? sender, WarpedEventArgs e)
        {
            this.Monitor.Log("wrap：" + e.NewLocation.Name, LogLevel.Debug);
            /*this.Monitor.Log($"event: {e.NewLocation.currentEvent.id}", LogLevel.Debug);*/
            if (Game1.dayOfMonth % 7 == 0)
            {
                this.Monitor.Log("今天星期天", LogLevel.Debug);
            } else
            {
                this.Monitor.Log("今天是星期：" + Game1.dayOfMonth % 7, LogLevel.Debug);
            }

            EventManager.triggerEvent(e.NewLocation);

            /*if (e.NewLocation.Name != "Custom_SaloonSecondFloor")
            {
                return;
            }*/

            /*var newEvent = new Event("continue/64 15/farmer 64 16 2 Lewis 64 18 0/broadcastEvent/addConversationTopic testa/skippable/pause 1000/emote farmer 8/speak Lewis \"你好呀！\"/emote farmer 32/speak Lewis \"你好？\"/emote farmer 32/speak Lewis \"你好~\"/end");
            

            e.NewLocation.startEvent(newEvent);*/

            /*if (e.NewLocation.currentEvent.id == "aaa")
            {
                e.NewLocation.currentEvent.onEventFinished += aaaa;
            }*/

            CookGameLocation.ActivateCompetitionKitchen();

        }

        private void aaaa()
        {
            throw new NotImplementedException();
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // print button presses to the console window
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        }
    }
}
