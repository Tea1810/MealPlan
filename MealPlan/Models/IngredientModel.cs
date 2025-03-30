using System.ComponentModel.DataAnnotations;

namespace MealPlan.Models
{
    public class IngredientModel
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public float IngredientQuantity { get; set; }
        public string IngredientMeasurement { get; set; }
        public int? NutritionId { get; set; }
        public NutritionModel? Nutrition { get; set; }
        public ICollection<RecipeIngredients>? RecipeIngredients { get; set; }

    }
}
