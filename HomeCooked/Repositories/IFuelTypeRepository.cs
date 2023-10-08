using HomeCooked.Models;

namespace HomeCooked.Repositories
{
    public interface IFuelTypeRepository
    {
        List<FuelType> GetFuelTypes();
    }
}