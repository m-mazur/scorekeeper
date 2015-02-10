using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreKeeper.Repositories;
using ScoreKeeper.Models;
using AutoMapper;

namespace ScoreKeeper.ViewModels
{
    public class GetAllScoresViewModel
    {
        private IScoreRepository scoreRepository;

        public GetAllScoresViewModel()
        {
            this.scoreRepository = new ScoreRepository();
        }
       
        public IEnumerable<GetAllScoresViewModel> GetAllScores()
        {
            Mapper.CreateMap<Score, GetAllScoresViewModel>();
            return Mapper.Map<IEnumerable<GetAllScoresViewModel>>(scoreRepository.GetAllScores());
        }

        public string UserName { get; set; }
        public int ScoreId { get; set; }
        public int ScorePoints { get; set; }
        public DateTime ScoreDate { get; set; }
    }
}
