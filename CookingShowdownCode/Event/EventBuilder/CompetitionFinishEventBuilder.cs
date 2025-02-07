using CookingShowdownCode.Enum;
using CookingShowdownCode.Event.Command;
using CookingShowdownCode.Helper;
using Netcode;
using StardewValley;
using StardewValley.Characters;
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

        //菜品的位置
        public static List<int> dishX = new List<int> { 12, 14, 16};
        public static int dishY = 11;
        public static int evaluateDishY = 10;//点评菜谱位置
        public static int hostX = 14;
        public static int hostY = 9;
        public static int competitorY = 14;

        private ActorPositionManager positionManager = new(); 

        public List<GameEventCommand> Build()
        {
            List<GameEventCommand> evaluate = new();            

            //调换任务位置，并注册NPC位置
            positionManager.insert(CharacterEnum.Lewis, 11, 7);
            evaluate.Add(new WarpCmd(CharacterEnum.Lewis, positionManager.getX(CharacterEnum.Lewis), positionManager.getY(CharacterEnum.Lewis)));

            positionManager.insert(CharacterEnum.Gus, hostX, hostY);
            evaluate.Add(new WarpCmd(CharacterEnum.Gus, positionManager.getX(CharacterEnum.Gus), positionManager.getY(CharacterEnum.Gus)));
            evaluate.Add(new FaceDirectionCmd(CharacterEnum.Gus,DirectionEnum.Down));

            //如果玩家没煮，也到旁边去
            if (!CompetitionContext.Instance.isPlayerCooked())
            {
                evaluate.Add(new WarpCmd(CharacterEnum.Farmer, 2, 6));
                evaluate.Add(new FaceDirectionCmd(CharacterEnum.Farmer, DirectionEnum.Right));
            }

            evaluate.AddRange(WarpCompetitor());

            //获取所有菜品，并摆放
            evaluate.AddRange(putDishToDesk());

            evaluate.Add(new GlobalFadeToClearCmd(0.007, true));
            evaluate.Add(ViewportCmd.viewPortReturn());
            evaluate.Add(new PauseCmd(1000));
            evaluate.Add(new SpeakICmd(CharacterEnum.Gus, "evaluate.ready"));
            evaluate.AddRange(evaluateAll());

            foreach(GameEventCommand command in evaluate)
            {
                Logger.Info(command.getCommandString());
            }

            return evaluate;
        }

        private List<GameEventCommand> WarpCompetitor()
        {
            List<GameEventCommand> result = new();
            int cnt = 0;

            foreach (var dish in CompetitionContext.Instance.getThreeCompetitionDish())
            {
                positionManager.insert(dish.who, dishX[cnt++], competitorY);
                result.Add(new WarpCmd(dish.who, positionManager.getX(dish.who), positionManager.getY(dish.who)));
                result.Add(new FaceDirectionCmd(dish.who, DirectionEnum.Up));
            }

            return result;
        }

        private List<GameEventCommand> evaluateAll()
        {
            List<GameEventCommand> result = new();
            List<RecipeSummary> summaryList = CompetitionContext.Instance.getThreeCompetitionDish();
            int cnt = 0;
            double maxScore = 0;
            CharacterEnum? maxIsWho = null;
            foreach (var summary in summaryList)
            {
                //评价之前要走到对应位置
                result.AddRange(moveToPoint(CharacterEnum.Gus, dishX[cnt++], evaluateDishY, DirectionEnum.Down));
                //开始评价
                result.AddRange(evaluateDish(summary));
                if (maxScore < summary.totalScore)
                {
                    maxScore = summary.totalScore;
                    maxIsWho = summary.who;
                } else if (maxScore == summary.totalScore && summary.who != CharacterEnum.Farmer)
                {
                    maxIsWho = summary.who;
                }
            }

            //走回主持人位置
            result.AddRange(moveToPoint(CharacterEnum.Gus, hostX, hostY, DirectionEnum.Down));

            //开始宣布冠军
            if (maxIsWho != null)
            {
                result.AddRange(whoWin(maxIsWho.Value));
            }

            //结束
            result.Add(new SpeakICmd(CharacterEnum.Gus, "evaluate.finish1"));
            result.Add(new SpeakICmd(CharacterEnum.Gus, "evaluate.finish2"));

            return result;
        }

        private List<GameEventCommand> moveToPoint(CharacterEnum who,int x,int y, DirectionEnum finalFace)
        {
            List<GameEventCommand> result = new();
            List<ActorMove> movePath = positionManager.moveToPoint(who, x, y);
            foreach (var move in movePath)
            {
                result.Add(new MoveCmd(who, move));
            }
            result.Add(new MoveCmd(who, 0, 0, finalFace));
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

        private List<GameEventCommand> putDishToDesk()
        {
            List<RecipeSummary> summaryList = CompetitionContext.Instance.getThreeCompetitionDish();
            int cnt = 0;

            List<GameEventCommand> result = new();
            foreach (var summary in summaryList)
            {
                result.Add(new AddDishToMapCmd(dishX[cnt++], dishY, summary.cookItem.ItemId));
            }
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
            List<String> bestItem = new();
            foreach (var ingredient in bestIngredients)
            {
                Item item = ItemRegistry.Create(ingredient);
                if (item != null)
                {
                    bestItem.Add(item.DisplayName);
                }
            }

            string IngredientList = string.Join("、", bestItem);

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

        private List<GameEventCommand> whoWin(CharacterEnum character)
        {
            List<GameEventCommand> result = new();
            result.Add(new SpeakICmd(CharacterEnum.Gus, $"evaluate.who_win1"));
            result.Add(new SpeakICmd(CharacterEnum.Gus, $"evaluate.who_win2", new { who = character.GetDisplayName() }));
            result.Add(new EmoteCmd(character,EmoteEnum.HeartEmote));

            //如果玩家赢得比赛，设置事件通过
            if (character == CharacterEnum.Farmer)
            {
                CompetitionContext.Instance.PlayerWin();
            }

            return result;
        }

        public List<GameEventCommand> notImpl()
        {
            var script = new List<GameEventCommand>();
            script.Add(new SpeakICmd(CharacterEnum.Gus, "notimpl"));
            return script;
        }
    }
}
