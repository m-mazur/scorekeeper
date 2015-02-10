using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreKeeper.Models;
using ScoreKeeper.Repositories;
using AutoMapper;

namespace ScoreKeeper.ViewModels
{
    public class GetSingleScoreViewModel
    {
        private IScoreRepository scoreRepository;

        public GetSingleScoreViewModel()
        {
            this.scoreRepository = new ScoreRepository();
        }

        public GetSingleScoreViewModel GetSingleScore(int scoreId)
        {
            Mapper.CreateMap<Score, GetSingleScoreViewModel>();
            return Mapper.Map<GetSingleScoreViewModel>(scoreRepository.GetScore(scoreId));
        }

        public int ScoreId { get; set; }
        public int ScorePoints { get; set; }
        public DateTime SoreDate { get; set; }
    }
}