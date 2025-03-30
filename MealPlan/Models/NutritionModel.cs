using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace MealPlan.Models
{
    public class NutritionModel
    {
        [Key]
        public int NutritionId { get; set; }
        public double Proteins {  get; set; }
        public double Carbohidrates { get; set; }
        public double Fats { get; set; }
        public double Calories { get; set; }
       
    }
}
