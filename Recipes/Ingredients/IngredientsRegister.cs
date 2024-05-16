using System.Collections.Generic;

namespace Cookie_Cookbook.Recipes.Ingredients
{
    public class IngredientsRegister : IIngredientsRegister
    {
        public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
        {
            new WheatFlour (),
            new SpeltFlour(),
            new Butter (),
            new Chocolate(),
            new Sugar(),
            new Cardamom(),
            new Cinnamon (),
            new CocoaPowder ()
        };

        public Ingredient GetById(int id)
        {
            foreach (var ingredient in All)
            {
                if (id == ingredient.ID)
                {
                    return ingredient;
                }
            }
            return null;
        }
    }
}
