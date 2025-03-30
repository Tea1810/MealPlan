using System.ComponentModel.DataAnnotations;

namespace MealPlan.Models
{
    public class RecipeModel
    {
        [Key]
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public DateTime RecipeDuration { get; set; }
        public string RecipeDifficulty { get; set; }
        public string RecipePreparationMode { get; set; }
        public ICollection<UserRecipe>? UserRecipes { get; set; }
        public ICollection<RecipeIngredients>? RecipeIngredients { get; set; }


    }
}
