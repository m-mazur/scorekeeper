using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ScoreKeeper.Models;

namespace ScoreKeeper.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ScoreKeeperRelease"].ConnectionString);

        public IEnumerable<Score> GetAllScores()
        {
            return this.db.Query<Score>("SELECT * FROM Scores INNER JOIN Users ON Scores.UserId = Users.UserId");
        }
    }
}