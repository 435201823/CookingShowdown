using CookingShowdownCode.Enum;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Helper
{
    public class ScoreCalculator
    {
        private CharacterEnum who;
        private String whoDisplayName;
        private Item? cookItem;
        private List<ItemStack>? ingredients;
        private int cookTimes;

        public ScoreCalculator(CharacterEnum who, String whoDisplayName, Item? cookItem, int cookTimes, List<ItemStack>? ingredients)
        {
            this.who = who;
            this.whoDisplayName = whoDisplayName;
            this.cookItem = cookItem;
            this.ingredients = ingredients;
            this.cookTimes = cookTimes;
        }

        public RecipeSummary? GetSummary()
        {
            if (cookItem == null || ingredients == null)
            {
                return null;
            }

            int price = cookItem.salePrice(true);
            int recipesCookedTimes = cookTimes;
            if (recipesCookedTimes >= 100)
            {
                recipesCookedTimes = 100;
            }

            double times = recipesCookedTimes;
            double total = price * ((times / 200) + 1);
            double maxScore = price * 1.5;
            double minScore = price;

            foreach (var ingredient in ingredients)
            {
                total *= (10.0 + (double)ingredient.quality) / 10.0;
                maxScore *= 1.4;
            }

            return new RecipeSummary(who,whoDisplayName, total, (total - minScore) / (maxScore - minScore), cookItem, recipesCookedTimes, ingredients);
        }
    }

    public class RecipeSummary
    {
        public CharacterEnum who;
        public String whoDisplayName;
        public double totalScore;
        public double recipeSpecialScore;
        public Item cookItem;
        public int cookTime;
        public List<ItemStack> ingredients;
        public double ingredientsAverageQuality;
        public bool someIngredientsQualityGtOrEq2 = false;
        public int bestQuality = 0;

        public RecipeSummary(CharacterEnum who,String whoDisplayName,double totalScore, double recipeSpecialScore, Item cookItem,int cookTime, List<ItemStack> ingredients)
        {
            this.who = who;
            this.whoDisplayName = whoDisplayName;
            this.totalScore = totalScore;
            this.recipeSpecialScore = recipeSpecialScore;
            this.cookItem = cookItem;
            this.cookTime = cookTime;
            this.ingredients = ingredients;

            foreach (var ingredient in ingredients)
            {
                ingredientsAverageQuality += ingredient.quality.getInt();
                if (ingredient.quality.getInt() >= 2)
                {
                    someIngredientsQualityGtOrEq2 = true;
                }
                if (ingredient.quality.getInt() > bestQuality)
                {
                    bestQuality = ingredient.quality.getInt();
                }
            }

            ingredientsAverageQuality /= ingredients.Count;
        }

        public bool hasIngredientsQualityGtOrEq2()
        {
            return someIngredientsQualityGtOrEq2;
        }

        public List<String> bestIngredients()
        {
            return ingredients.Where(x => x.quality.getInt() == bestQuality).Select(x => x.itemId).ToList();
        }
    }
}
