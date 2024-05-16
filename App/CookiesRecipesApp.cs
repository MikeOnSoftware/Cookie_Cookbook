using System.Linq;
using Cookie_Cookbook.Recipes;

namespace Cookie_Cookbook.App
{
    public class CookiesRecipesApp
    //a class to implement the main workflow, defined in the requirments
    {
        //since these two types below are dependencies of this class,
        //we declare their private readonly interfaces here and pass (inject) them as parameters in the ctor
        //to be implemented outside as in line with the DEPENDENCY INJECTION principal

        private readonly IRecipesRepository _recipesRepository;
        private readonly IRecipesUserInteraction _recipesUserInteraction;

        public CookiesRecipesApp(
            IRecipesRepository recipesRepository,
            IRecipesUserInteraction recipesUserInteraction)
        {
            _recipesRepository = recipesRepository;
            _recipesUserInteraction = recipesUserInteraction;
        }

        public void Run(string filePath)
        {
            var allRecipes = _recipesRepository.Read(filePath);
            _recipesUserInteraction.PrintExistingRecipes(allRecipes);

            _recipesUserInteraction.PromptToCreateRecipe();
            var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

            if (ingredients.Count() > 0)
            {
                var recipe = new Recipe(ingredients);
                allRecipes.Add(recipe);
                _recipesRepository.Write(filePath, allRecipes);

                _recipesUserInteraction.ShowMessage("Recipe added:");
                _recipesUserInteraction.ShowMessage(recipe.ToString());
            }
            else
            {
                _recipesUserInteraction.ShowMessage(
                "No ingredients have been selected." +
                "Recipe will not be saved.");
            }

            _recipesUserInteraction.Exit();
        }
    }
}
