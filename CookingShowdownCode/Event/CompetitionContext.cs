using CookingShowdownCode.Dish;
using CookingShowdownCode.Enum;
using CookingShowdownCode.Helper;
using StardewValley;

namespace CookingShowdownCode.Event
{
    public class CompetitionContext
    {
        private static CompetitionContext? _instance = null;

        private static string eventPrefix = "202412191635";

        private bool isBlockMenu = false;

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

        public RecipeSummary? getPlayerRecipeSummary()
        {
            ScoreCalculator calc = new(Game1.player.userID.ToString(), Game1.player.displayName, cookItem, ingredients);
            return calc.GetSummary();
        }
        
        public bool isFirstCompetition()
        {
            return Game1.player.eventsSeen.Contains(eventPrefix + "000");
        }

        public CompetitionLevelEnum getLevel()
        {
            
            if (Game1.player.eventsSeen.Contains(eventPrefix + "016"))
            {
                return CompetitionLevelEnum.LV16;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "015"))
            {
                return CompetitionLevelEnum.LV16;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "014"))
            {
                return CompetitionLevelEnum.LV15;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "013"))
            {
                return CompetitionLevelEnum.LV14;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "012"))
            {
                return CompetitionLevelEnum.LV13;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "011"))
            {
                return CompetitionLevelEnum.LV12;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "010"))
            {
                return CompetitionLevelEnum.LV11;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "009"))
            {
                return CompetitionLevelEnum.LV10;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "008"))
            {
                return CompetitionLevelEnum.LV9;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "007"))
            {
                return CompetitionLevelEnum.LV8;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "006"))
            {
                return CompetitionLevelEnum.LV7;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "005"))
            {
                return CompetitionLevelEnum.LV6;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "004"))
            {
                return CompetitionLevelEnum.LV5;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "003"))
            {
                return CompetitionLevelEnum.LV4;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "002"))
            {
                return CompetitionLevelEnum.LV3;
            }
            else if (Game1.player.eventsSeen.Contains(eventPrefix + "001"))
            {
                return CompetitionLevelEnum.LV2;
            }
            return CompetitionLevelEnum.LV1;
        }

        public List<RecipeSummary> getAllNpcCompetitionDish(CompetitionLevelEnum levelEnum)
        {
            List<RecipeSummary> result = new List<RecipeSummary>();

            result.Add(npcCook(CharacterEnum.Jas, new DishFriedEgg(QualityEnum.Silver)));
            var playerRecipeSummary = getPlayerRecipeSummary();
            if (playerRecipeSummary != null)
            {
                result.Add(playerRecipeSummary);
            }

            return result;
        }

        public List<RecipeSummary> getThreeCompetitionDish()
        {
            var level = getLevel();
            List<RecipeSummary> dishSummaryList = getAllNpcCompetitionDish(level);
            if (dishSummaryList.Count < 3)
            {
                return dishSummaryList;
            }

            //获取前三个
            return dishSummaryList.Take(3).ToList();
        }

        private static RecipeSummary npcCook(CharacterEnum who, IDish dish)
        {
            return npcCook(who, dish.getCookItemId(), dish.getIngredients());
        }

        private static RecipeSummary npcCook(CharacterEnum who,String cookItemId, List<ItemStack> ingredients)
        {
            Item cookItem = ItemRegistry.Create(cookItemId);
            ScoreCalculator calc = new ScoreCalculator(who.GetName(), who.GetDisplayName(), cookItem, ingredients);

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
    }
}
