using HomeCooked.Models;
using HomeCooked.Utils;

namespace HomeCooked.Repositories
{
    public class MealRepository : BaseRepository, IMealRepository
    {
        public MealRepository(IConfiguration configuration) : base(configuration) { }

        public List<Meal> GetAllMeals()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                             m.id
                                            ,m.main_dish AS MainDish
                                            ,m.side_dish_1 AS SideDish1
                                            ,m.side_dish_2 AS SideDish2
                                            ,ft.fuel_type_name AS FuelType
                                        FROM meals m
                                        JOIN fuel_types ft 
                                          ON ft.id = m.fuel_type_id";

                    var reader = cmd.ExecuteReader();

                    var meals = new List<Meal>();

                    while (reader.Read())
                    {
                        var meal = new Meal()
                        {
                            Id = DbUtils.GetInt(reader, "id"),
                            MainDish = DbUtils.GetString(reader, "MainDish"),
                            SideDish1 = DbUtils.GetString(reader, "SideDish1"),
                            SideDish2 = DbUtils.GetString(reader, "SideDish2"),
                            FuelType = new FuelType()
                            {
                                FuelTypeName = DbUtils.GetString(reader, "FuelType")
                            }
                        };

                        meals.Add(meal);
                    }
                    conn.Close();
                    return meals;
                }
            }
        }
    }
}


