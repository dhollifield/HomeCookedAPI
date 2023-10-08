namespace HomeCooked.Models
{
    public class UserMeal
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MealId { get; set; }

        public int MealTypeId { get; set; }

        public DateTime MealDate { get; set; }

        public Meal Meal { get; set; }

        public FuelType FuelTypeName { get; set; }

        public MealType MealTypeName { get; set; }

    }
}
