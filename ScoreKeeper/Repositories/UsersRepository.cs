using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreKeeper.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Configuration;

namespace ScoreKeeper.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ScoreKeeperRelease"].ConnectionString);

        public IEnumerable<User> GetAllUsers()
        {
            var sqlCmd = "SELECT * FROM Users";
            return this.db.Query<User>(sqlCmd);
        }
    }
}