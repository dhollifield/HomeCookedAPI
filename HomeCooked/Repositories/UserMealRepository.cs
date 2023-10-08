using HomeCooked.Models;
using HomeCooked.Utils;

namespace HomeCooked.Repositories
{
    public class UserMealRepository : BaseRepository, IUserMealRepository
    {
        public UserMealRepository(IConfiguration configuration) : base(configuration) { }

        public List<UserMeal> GetAllUserMeals(int id, DateTime today)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT u.id
	                                   ,um.meal_date AS MealDate
	                                   ,mt.id
	                                   ,mt.meal_type_name AS MealTypeName
	                                   ,m.main_dish AS MainDish
	                                   ,m.side_dish_1 AS SideDish1
	                                   ,m.side_dish_2 AS SideDish2
	                                   ,ft.fuel_type_name AS FuelTypeName
                                  FROM user_meals um
                                  JOIN users u ON u.id = um.user_id 
                                  JOIN meals m ON m.id = um.meal_id
                                  JOIN fuel_types ft ON ft.id = m.fuel_type_id
                                  JOIN meal_types mt ON mt.id = um.meal_type_id
                                 WHERE u.id = @id AND um.meal_date = @DATETIME
                              ORDER BY um.meal_date, mt.id";

                    DbUtils.AddParameter(cmd, "@id", id);
                    DbUtils.AddParameter(cmd, "@DATETIME", today);

                    var reader = cmd.ExecuteReader();

                    var userMeal = new List<UserMeal>();

                    while (reader.Read())
                    {
                        userMeal.Add(new UserMeal()
                        {
                            Id = id,
                            MealDate = DbUtils.GetDateTime(reader, "MealDate"),
                            MealTypeName = new MealType()
                            {
                                MealTypeName = DbUtils.GetString(reader, "MealTypeName")
                            },
                            Meal = new Meal()
                            {
                                MainDish = DbUtils.GetString(reader, "MainDish"),
                                SideDish1 = DbUtils.GetString(reader, "SideDish1"),
                                SideDish2 = DbUtils.GetString(reader, "SideDish2"),
                                FuelType = new FuelType()
                                {
                                    FuelTypeName = DbUtils.GetString(reader, "FuelTypeName")
                                }
                            }
                        });
                    }
                    reader.Close();

                    return userMeal;
                }
            }
        }
    }
}
