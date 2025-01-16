using CookingShowdownCode.Enum;
using CookingShowdownCode.Event.Command;
using CookingShowdownCode.Helper;
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
        public List<GameEventCommand> Build()
        {
            List<GameEventCommand> evaluate = new();

            //调换任务位置
            evaluate.Add(new WarpCmd(CharacterEnum.Lewis, 11, 7));
            evaluate.Add(new WarpCmd(CharacterEnum.Gus, 14, 9));
            evaluate.Add(new FaceDirectionCmd(CharacterEnum.Gus,DirectionEnum.Down));

            evaluate.Add(new GlobalFadeToClearCmd(0.007, true));
            evaluate.Add(ViewportCmd.viewPortReturn());
            evaluate.Add(new PauseCmd(1000));
            evaluate.Add(new SpeakICmd(CharacterEnum.Gus, "evaluate.ready"));
            evaluate.AddRange(evaluateAll());

            return evaluate;
        }

        private List<GameEventCommand> evaluateAll()
        {
            List<GameEventCommand> result = new();

            List<RecipeSummary> summaryList = CompetitionContext.Instance.getThreeCompetitionDish();
            foreach (var summary in summaryList)
            {
                result.AddRange(evaluateDish(summary));
            }

            return result;
        }

        private List<GameEventCommand> evaluateDish(RecipeSummary recipeSummary)
        {
            if (recipeSummary == null)
            {
                return new();
            }

            List<GameEventCommand> result = new();
            result.Add(sayDishName(recipeSummary.whoDisplayName,recipeSummary.cookItem.DisplayName));
            result.Add(eat());
            result.Add(ingredientsAverageQuality(recipeSummary.ingredientsAverageQuality));
            if (recipeSummary.hasIngredientsQualityGtOrEq2())
            {
                result.Add(bestIngredients(recipeSummary.bestQuality, recipeSummary.bestIngredients()));
            }
            result.Add(eat());
            result.Add(cookTimes(recipeSummary.cookTime));


            return result;
        }

        private GameEventCommand sayDishName(String CookerDisplayName,String DishName)
        {
            int random = Game1.random.Next(1,4);
            return new SpeakICmd(CharacterEnum.Gus, $"evaluate.say_dish_name{random}", new { CookerDisplayName, DishName});
        }

        private GameEventCommand eat()
        {
            return new SpeakICmd(CharacterEnum.Gus, "evaluate.eat");
        }

        private GameEventCommand ingredientsAverageQuality(double ingredientsAverageQuality)
        {
            int quality = 0;
            if (ingredientsAverageQuality < 1)
            {
                quality = 0;
            }
            else if (ingredientsAverageQuality < 2)
            {
                quality = 1;
            }
            else if (ingredientsAverageQuality < 4)
            {
                quality = 2;
            }
            else
            {
                quality = 4;
            }

            int random = Game1.random.Next(1, 7);
            return new SpeakICmd(CharacterEnum.Gus, $"evaluate.ingredients_quality{quality}_evaluation{random}");
        }

        private GameEventCommand bestIngredients(int Quality, List<String> bestIngredients)
        {
            string IngredientList = string.Join("、", bestIngredients);

            int random = Game1.random.Next(1, 4);
            return new SpeakICmd(CharacterEnum.Gus, $"evaluate.single_ingredient_quality{Quality}_evaluation{random}", new { IngredientList });
        }

        private GameEventCommand cookTimes(int cookTime)
        {
            int random = Game1.random.Next(1, 7);
            int cookLowerThen = 0;
            if (cookTime < 5)
            {
                cookLowerThen = 5;
            } else if (cookTime < 50) 
            {
                cookLowerThen = 50;
            }
            else if (cookTime < 100)
            {
                cookLowerThen = 100;
            } else
            {
                return new SpeakICmd(CharacterEnum.Gus, $"evaluate.cook_time_not_lower_then_100_times_{random}");
            }
            return new SpeakICmd(CharacterEnum.Gus, $"evaluate.cook_time_lower_then_{cookLowerThen}_times_{random}");
        }

        public List<GameEventCommand> notImpl()
        {
            var script = new List<GameEventCommand>();
            script.Add(new SpeakICmd(CharacterEnum.Gus, "notimpl"));
            return script;
        }
    }
}
