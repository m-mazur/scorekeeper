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

        // GET api/Scores
        public IEnumerable<Score> GetScores()
        {
            return scoreRepository.GetAllScores();
        }

        // GET api/Scores/5
        public Score GetScore(int id)
        {
            Score score = scoreRepository.GetScore(id);

            if (score == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return scoreRepository.GetScore(id);
        }

        // POST api/Scores
        public void PostScore(Score score)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            scoreRepository.AddScore(score);
        }
    }
}