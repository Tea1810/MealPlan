using System.ComponentModel.DataAnnotations;

namespace MealPlan.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserNickname { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public ICollection<UserRecipe>? UserRecipes { get; set; }
    }
}
