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
            var allScores = Mapper.Map<IEnumerable<GetAllScoresViewModel>>(scoreRepository.GetAllScores());
           
            if (allScores == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return allScores;
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
            var score = Mapper.Map<GetSingleScoreViewModel>(scoreRepository.GetScore(id));

            if (score == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            scoreRepository.DeleteScore(id);
        }
    }
}