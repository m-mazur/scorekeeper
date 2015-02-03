using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ScoreKeeper.Models;
using ScoreKeeper.Repositories;

namespace ScoreKeeper.Controllers
{
    public class ScoresController : ApiController
    {
        private ScoreRepository scoreRepository = new ScoreRepository();

        // GET api/Scores/GetScores
        public IEnumerable<Score> GetScore()
        {
            return scoreRepository.GetAllScores();
        }

        // GET api/Scores/GetScores/5
        public Score GetScore(int id)
        {
            Score score = scoreRepository.GetScore(id);

            if (score == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return scoreRepository.GetScore(id);
        }

        // GET api/Scores/GetLatestScore
        public Score GetLatestScore()
        {
            Score score = scoreRepository.GetLatestScore();

            if (score == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return scoreRepository.GetLatestScore();
        }

        // POST api/Scores/PostScore
        public void PostScore(Score score)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            scoreRepository.AddScore(score);
        }

        // DELETE api/Scores/DeleteScore/5
        public void DeleteScore(int id)
        {
            Score score = scoreRepository.GetScore(id);

            if (score == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            scoreRepository.DeleteScore(score.ScoreId);
        }
    }
}