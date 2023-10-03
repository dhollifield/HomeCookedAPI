using HomeCooked.Models;
using HomeCooked.Utils;

namespace HomeCooked.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public List<User> GetAllUsers()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                             id
                                            ,first_name
                                            ,last_name
                                            ,email
                                        FROM users";

                    var reader = cmd.ExecuteReader();

                    var users = new List<User>();

                    while (reader.Read())
                    {
                        var user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "id"),
                            FirstName = DbUtils.GetString(reader, "first_name"),
                            LastName = DbUtils.GetString(reader, "last_name"),
                            Email = DbUtils.GetString(reader, "email")
                        };

                        users.Add(user);
                    }
                    conn.Close();
                    return users;
                }
            }
        }
    }
}
