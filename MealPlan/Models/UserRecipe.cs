using System.ComponentModel.DataAnnotations;

namespace MealPlan.Models
{
    public class UserRecipe
    {
        [Key]
        public int UserRecipeId { get; set; }
        public int UserId { get; set; }
        public UserModel? User { get; set; }
        public int RecipeId { get; set; }
        public RecipeModel? Recipe { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsShared { get; set; }
    }
}
