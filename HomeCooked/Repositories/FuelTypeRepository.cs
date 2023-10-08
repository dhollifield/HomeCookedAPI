using HomeCooked.Models;
using HomeCooked.Utils;
using System.Security.Cryptography;

namespace HomeCooked.Repositories
{
    public class FuelTypeRepository : BaseRepository, IFuelTypeRepository
    {
        public FuelTypeRepository(IConfiguration configuration) : base(configuration) { }

        public List<FuelType> GetFuelTypes()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, fuel_type_name AS FuelType FROM fuel_types";

                    var reader = cmd.ExecuteReader();

                    var fuelType = new List<FuelType>();

                    while (reader.Read())
                    {
                        fuelType.Add(new FuelType()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FuelTypeName = DbUtils.GetString(reader, "FuelType")
                        });
                    }
                    reader.Close();
                    return fuelType;
                }
            }
        }
    }
}
