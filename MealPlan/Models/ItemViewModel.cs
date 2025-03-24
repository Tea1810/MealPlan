using System.ComponentModel.DataAnnotations;

namespace MealPlan.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Quantity { get; set; }

    }
}
