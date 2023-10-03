using HomeCooked.Models;

namespace HomeCooked.Repositories
{
    public interface IMealRepository
    {
        List<Meal> GetAllMeals();
    }
}