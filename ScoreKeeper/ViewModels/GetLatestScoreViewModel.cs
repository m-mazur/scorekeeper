using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreKeeper.Repositories;
using ScoreKeeper.Models;
using AutoMapper;

namespace ScoreKeeper.ViewModels
{
    public class GetLatestScoreViewModel
    {
        private ScoreRepository scoreRepository;

        public GetLatestScoreViewModel()
        {
            scoreRepository = new ScoreRepository();
        }

        public GetLatestScoreViewModel GetScore()
        {
            Mapper.CreateMap<Score, GetLatestScoreViewModel>();
            return Mapper.Map<GetLatestScoreViewModel>(scoreRepository.GetLatestScore());
        }

        public string UserName { get; set; }
        public int ScoreId { get; set; }
        public int ScorePoints { get; set; }
        public DateTime ScoreDate { get; set; }
    }
}