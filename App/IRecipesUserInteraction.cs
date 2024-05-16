using System.Collections.Generic;
using Cookie_Cookbook.Recipes;
using Cookie_Cookbook.Recipes.Ingredients;

namespace Cookie_Cookbook.App
{
    public interface IRecipesUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
        void PromptToCreateRecipe();

        IEnumerable<Ingredient> ReadIngredientsFromUser();
    }
}
