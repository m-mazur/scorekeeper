using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ScoreKeeper.Models;
using System.Data.Entity;

namespace ScoreKeeper.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ScoreKeeperRelease"].ConnectionString);
    
        public IEnumerable<Score> GetAllScores()
        {
            var sqlCmd = "SELECT * FROM Scores INNER JOIN Users ON Scores.UserId = Users.UserId ORDER BY ScoreDate DESC";
            return this.db.Query<Score>(sqlCmd);
        }

        public Score GetScore(int id)
        {
            var sqlCmd = "SELECT * FROM Scores INNER JOIN Users ON Scores.UserId = Users.UserId WHERE Scores.ScoreId = @paramId";
            return this.db.Query<Score>(sqlCmd, 
                new { 
                    paramId = id 
                }).FirstOrDefault();
        }

        public Score GetLatestScore()
        {
            var sqlCmd = "SELECT * FROM Scores INNER JOIN Users ON Scores.UserId = Users.UserId WHERE Scores.ScoreId = (SELECT TOP 1 ScoreId FROM Scores ORDER BY ScoreId DESC)";
            return this.db.Query<Score>(sqlCmd).FirstOrDefault();
        }

        public void AddScore(Score score) 
        {
            var sqlCmd = "INSERT INTO dbo.Scores (ScorePoints, ScoreDate, UserId) VALUES(@scorePoints, @scoreDate, @userId)";
            this.db.Query<Score>(sqlCmd, 
                new { 
                    scorePoints = score.ScorePoints, 
                    scoreDate = DateTime.Now, 
                    userId = score.UserId
                });
        }

        public void DeleteScore(int id)
        {
            var sqlCmd = "DELETE FROM dbo.Scores WHERE ScoreId = @scoreId";
            this.db.Query<Score>(sqlCmd,
                new
                {
                    scoreId = id
                });
        }
    }
}