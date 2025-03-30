using Microsoft.EntityFrameworkCore;

namespace MealPlan.Models
{
    public class MealDbContext : DbContext
    {
        public MealDbContext(DbContextOptions<MealDbContext> options)
            : base(options) 
        {
        }

        public DbSet<UserModel>? Users { get; set; }
        public DbSet<RecipeModel>? Recipes { get; set; }
        public DbSet<IngredientModel>? Ingredients { get; set; }
        public DbSet<NutritionModel>? Nutritions { get; set; }
        public DbSet<RecipeIngredients>? RecipeIngredients { get; set; }
        public DbSet<UserRecipe>? UserRecipes { get; set; }

    }
}
