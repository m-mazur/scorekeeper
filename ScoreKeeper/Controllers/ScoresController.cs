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
using ScoreKeeper.ViewModels;

namespace ScoreKeeper.Controllers
{

    public class ScoresController : ApiController
    {
        private ScoreRepository scoreRepository = new ScoreRepository();
        private GetScoresViewModel getScoresViewModel = new GetScoresViewModel();

        // GET api/Scores/GetAllScores
        public IEnumerable<GetScoresViewModel> GetAllScores()
        {
            if (getScoresViewModel.GetAllScores() == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return getScoresViewModel.GetAllScores();
        }

        // GET api/Scores/GetScores
        public IEnumerable<Score> GetScore()
        {
            return scoreRepository.GetAllScores();
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