using Cookie_Cookbook.App;
using Cookie_Cookbook.DataAccess;
using Cookie_Cookbook.FileAccess;
using Cookie_Cookbook.Recipes;
using Cookie_Cookbook.Recipes.Ingredients;

namespace Cookie_Cookbook
{
    public class Program
    {
        static void Main(string[] args)
        {
            const FileFormat Format = FileFormat.Json; //can be set to change by the user 

            IStringsRepository stringsRepository;
            if (Format == FileFormat.Json) stringsRepository = new StringsJsonRepository();
            else stringsRepository = new StringsTextualRepository();

            /// Ternary conditional operatoronly available in c# 9+
            ///IStringsRepository stringsRepository = Format == FileFormat.Json ?
            ///    new StringsJasonRepository() :
            ///    new StringsTextualRepository();

            const string FileName = "recipes";
            var fileMetadata = new FileMetadata(FileName, Format);

            var ingredientsRegister = new IngredientsRegister();

            var cookiesRecipesApp = new CookiesRecipesApp(
                new RecipesRepository(new StringsTextualRepository(), ingredientsRegister),
                new RecipesConsoleUserInteraction(ingredientsRegister));
            cookiesRecipesApp.Run(fileMetadata.ToPath());
        }
    }
}
