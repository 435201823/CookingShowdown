using CookingShowdownCode.Dish;
using CookingShowdownCode.Enum;
using CookingShowdownCode.Event.Level;
using CookingShowdownCode.Helper;
using StardewValley;
using System.Linq;

namespace CookingShowdownCode.Event
{
    public class CompetitionContext
    {
        private static CompetitionContext? _instance = null;

        

        private bool isBlockMenu = false;

        private List<RecipeSummary> threeCompetitionDishCache;

        public static CompetitionContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompetitionContext();
                }
                return _instance;
            }
        }

        public static void clearAndInit()
        {
            _instance = new CompetitionContext();
        }

        private CompetitionContext()
        {
        }

        private Item? cookItem;

        private List<ItemStack>? ingredients;

        internal void CompetitionStart()
        {
            this.cookItem = null;
            var level = getLevel();
            Logger.Info($"当前比赛等级：{level}");
        }

        public void setCookItem(Item item)
        {
            this.cookItem = item;
        }

        public Item? getCookItem()
        {
            return this.cookItem;
        }

        internal async Task WaitForCook()
        {
            while(this.cookItem == null && Game1.activeClickableMenu != null)
            {
                await Task.Delay(100);
            }
        }

        public void setIngredient(List<ItemStack> dictionary)
        {
            this.ingredients = dictionary;
        }

        public bool isPlayerCooked()
        {
            return cookItem != null;
        }

        public RecipeSummary? getPlayerRecipeSummary()
        {
            //暂时不支持联机，如果联机，考虑Game1.player.userID.ToString()

            if (cookItem == null)
            {
                return null;
            }

            int cookTimes = Game1.player.recipesCooked[cookItem.ItemId];

            ScoreCalculator calc = new(CharacterEnum.Farmer, Game1.player.displayName, cookItem, cookTimes, ingredients);

            var result = calc.GetSummary();
            if (EventManager.debug && result!= null)
            {
                result.totalScore = 100000;
            }

            return result;
        }
        
        public bool isFirstCompetition()
        {
            return !Game1.player.eventsSeen.Contains(CompetitionLevelEnumExtensions.firstEvent);
        }

        public static void setSeenFirstCompetition()
        {
            Game1.player.eventsSeen.Add(CompetitionLevelEnumExtensions.firstEvent);
        }

        public CompetitionLevelEnum getLevel()
        {
            for (int i = 0; i < 16; i++)
            {
                var level = CompetitionLevelEnumExtensions.from(i);
                Logger.Info($"i:{i}");
                Logger.Info($"是否是比赛等级：{level}");
                if (!Game1.player.eventsSeen.Contains(level.ToEventIdString()))
                {
                    return level;
                }
            }

            return CompetitionLevelEnum.LV1;
        }

        //只有NPC的菜
        public List<RecipeSummary> getAllNpcCompetitionDish(CompetitionLevelEnum levelEnum)
        {
            List<RecipeSummary> result = new List<RecipeSummary>();

            var level = ICompetionLevel.getLevel(levelEnum);
            result.AddRange(level.getThreeCompetitionDish());

            return result;
        }

        public List<RecipeSummary> getThreeCompetitionDish()
        {
            if (threeCompetitionDishCache != null)
            {
                return threeCompetitionDishCache;
            }

            var level = getLevel();
            List<RecipeSummary> dishSummaryList = getAllNpcCompetitionDish(level);

            //打日志
            foreach ( var dish in dishSummaryList)
            {
                Logger.Info($"npc选手{dish.whoDisplayName}的评分是：{dish.totalScore}");
            }

            var playerRecipeSummary = getPlayerRecipeSummary();
            if (playerRecipeSummary != null)
            {
                Logger.Info($"玩家的评分是：{playerRecipeSummary.totalScore}");
                //如果玩家参与比赛
                //先将NPC的菜排序
                dishSummaryList.Sort((x, y) => y.totalScore.CompareTo(x.totalScore));
                //选出前两名
                threeCompetitionDishCache = dishSummaryList.Take(2).ToList();
                //将玩家菜加入
                threeCompetitionDishCache.Add(playerRecipeSummary);
                return threeCompetitionDishCache;
            }

            threeCompetitionDishCache = dishSummaryList.Take(3).ToList();
            return threeCompetitionDishCache;
        }

        public static RecipeSummary npcCook(CharacterEnum who, IDish dish, int cookTime)
        {
            return npcCook(who, dish.getCookItemId(), cookTime,dish.getIngredients());
        }

        public static RecipeSummary npcCook(CharacterEnum who,String cookItemId, int cookTime, List<ItemStack> ingredients)
        {
            Item cookItem = ItemRegistry.Create(cookItemId);
            ScoreCalculator calc = new ScoreCalculator(who, who.GetDisplayName(), cookItem, cookTime, ingredients);

            var summary = calc.GetSummary();

            if (summary == null)
            {
                throw new Exception("An unexpected error occurred, summary should not be empty");
            }

            return summary;
        }

        public bool blockMenu()
        {
            if (isBlockMenu)
            {
                return false;
            }

            isBlockMenu = true;
            return true;
        }

        public void unblockMenu()
        {
            isBlockMenu = false;
        }

        internal void PlayerWin()
        {
            //玩家获胜，设置当前等级通过
            CompetitionLevelEnum level = getLevel();
            var eventId = level.ToEventIdString();
            Game1.player.eventsSeen.Add(eventId);
            Logger.Info($"玩家赢得比赛，eventsSeen添加: {eventId}");
        }
    }
}
