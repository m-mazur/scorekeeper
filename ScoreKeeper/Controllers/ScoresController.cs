using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ScoreKeeper.ViewModels;
using ScoreKeeper.Repositories;
using ScoreKeeper.Models;
using AutoMapper;

namespace ScoreKeeper.Controllers
{

    public class ScoresController : ApiController
    {
        private IScoreRepository scoreRepository;

        public ScoresController()
        {
            scoreRepository = new ScoreRepository();
        }

        // GET api/Scores/GetAllScores
        public IEnumerable<GetAllScoresViewModel> GetAllScores()
        {
            try
            {
                var allScores = Mapper.Map<IEnumerable<GetAllScoresViewModel>>(scoreRepository.GetAllScores());
                return allScores;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // GET api/Scores/GetLatestScore
        public GetLatestScoreViewModel GetLatestScore()
        {
            var latestScore = Mapper.Map<GetLatestScoreViewModel>(scoreRepository.GetLatestScore());

            if (latestScore == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return latestScore;
        }

        // POST api/Scores/PostScore
        public void PostScore(AddScoreViewModel addScoreViewModel)
        {
            var score = Mapper.Map<Score>(addScoreViewModel);
            
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            scoreRepository.AddScore(score);
        }

        // DELETE api/Scores/DeleteScore/5
        public void DeleteScore(int id)
        {
            try
            {
                var score = Mapper.Map<GetSingleScoreViewModel>(scoreRepository.GetScore(id));
                scoreRepository.DeleteScore(id);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}