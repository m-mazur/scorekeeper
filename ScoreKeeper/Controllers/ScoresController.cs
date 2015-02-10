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
        private ScoreRepository scoreRepository;
        private GetAllScoresViewModel getAllScoresViewModel;
        private GetLatestScoreViewModel getLatestScoreViewModel;
        private AddScoreViewModel addScoreViewModel;

        public ScoresController()
        {
            scoreRepository = new ScoreRepository();
            getAllScoresViewModel = new GetAllScoresViewModel();
            getLatestScoreViewModel = new GetLatestScoreViewModel();
            addScoreViewModel = new AddScoreViewModel();
        }

        // GET api/Scores/GetAllScores
        public IEnumerable<GetAllScoresViewModel> GetAllScores()
        {
            IEnumerable<GetAllScoresViewModel> allScores = getAllScoresViewModel.GetAllScores();
           
            if (allScores == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return allScores;
        }

        // GET api/Scores/GetLatestScore
        public GetLatestScoreViewModel GetLatestScore()
        {
            GetLatestScoreViewModel latestScore = getLatestScoreViewModel.GetScore();

            if (latestScore == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return latestScore;
        }

        // POST api/Scores/PostScore
        public void PostScore(AddScoreViewModel scoreViewModel)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            scoreViewModel.AddScore(scoreViewModel);
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