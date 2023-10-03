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
                                             id
                                            ,main_dish
                                            ,side_dish_1 
                                            ,side_dish_2
                                        FROM meals";

                    var reader = cmd.ExecuteReader();

                    var meals = new List<Meal>();

                    while (reader.Read())
                    {
                        var meal = new Meal()
                        {
                            Id = DbUtils.GetInt(reader, "id"),
                            MainDish = DbUtils.GetString(reader, "main_dish"),
                            SideDish1 = DbUtils.GetString(reader, "side_dish_1"),
                            SideDish2 = DbUtils.GetString(reader, "side_dish_2")
                        };

                        meals.Add(meal);
                    }
                    conn.Close();
                    return meals;
                }
            }
        }

        //public List<Meal> GetUserMeals()
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open(); 
        //        using (var cmd = conn.CreateCommand())

                
        //    }
        //}

    }
}


