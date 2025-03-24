using System.ComponentModel.DataAnnotations;

namespace MealPlan.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public string Difficulty { get; set; }

        public string Preparation { get; set; }


    }
}
