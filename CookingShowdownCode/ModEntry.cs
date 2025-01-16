using CookingShowdownCode.Event;
using CookingShowdownCode.Event.Command;
using CookingShowdownCode.Event.EventBuilder;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Delegates;
using StardewValley.Menus;
using StardewValley.Monsters;
using System.Diagnostics;
using System.Reflection;

namespace CookingShowdownCode
{
    internal sealed class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            initEventCommand();
            Logger.Init(this.Monitor);

            //init i18n
            InnerTranslator.init(this.Helper.Translation);

            //helper.GameContent.InvalidateCache

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
            EventManager.triggerEvent(e.NewLocation);
        }

        private void initEventCommand()
        {
            List<MethodInfo?> methodInfos = new()
            {
                typeof(ShowCompetitionKitchenCmd).GetMethod("ShowCompetitionKitchen"),
                typeof(AddDishToMapCmd).GetMethod("AddDishToMap"),
                typeof(GenerateEvaluationCmd).GetMethod("GenerateEvaluation")
            };
            foreach (var method in methodInfos) {
                if (method != null)
                {
                    EventCommandDelegate eventCommandDelegate = (EventCommandDelegate)Delegate.CreateDelegate(typeof(EventCommandDelegate), method);
                    StardewValley.Event.RegisterCommand(method.Name, eventCommandDelegate);
                }
            }
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

            if (e.Button == SButton.F9)
            {
                EventManager.debug = true;
                Game1.warpFarmer("Custom_SaloonSecondFloor", 14,15, 2);
                
                //获取location
                //var @event = new StardewValley.Event("continue/64 15/farmer 64 16 2 Lewis 64 18 0/skippable/addDishToMap 63 16 194/pause 10000/end");
                //@event.onEventFinished += CompetitionOpenSpeechEventBuilder.onEventFinish;
                //Game1.currentLocation.startEvent(@event);
                ////CookGameLocation.ActivateCompetitionKitchen();
            }

            // print button presses to the console window
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        }

        
    }
}
