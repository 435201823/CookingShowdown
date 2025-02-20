using CookingShowdownCode.Event;
using CookingShowdownCode.Event.Command;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Delegates;
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

            //helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.Player.Warped += this.OnWarped;
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

        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;
            if (e.Button == SButton.F10)
            {
                learnAll();
            }
            if (e.Button == SButton.F9)
            {
                EventManager.debug = true;
                Game1.warpFarmer("Custom_SaloonSecondFloor", 14,15, 2);
            }
        }

        private void learnAll()
        {
            for (int i = 200;i < 922; i++)
            {
                string itemStr = i.ToString();
                Item cookItem = ItemRegistry.Create(itemStr);

                cookItem.LearnRecipe();
            }
        }
    }
}
