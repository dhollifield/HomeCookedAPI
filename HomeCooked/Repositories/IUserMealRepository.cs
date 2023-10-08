using HomeCooked.Models;

namespace HomeCooked.Repositories
{
    public interface IUserMealRepository
    {
        List<UserMeal> GetAllUserMeals(int id, DateTime today);
    }
}