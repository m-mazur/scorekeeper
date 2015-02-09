using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreKeeper.Repositories;
using ScoreKeeper.Models;
using AutoMapper;

namespace ScoreKeeper.ViewModels
{
    public class GetScoresViewModel
    {
        private ScoreRepository scoreRepository = new ScoreRepository();

        public string UserName { get; set; }
        public int ScorePoints { get; set; }
        public DateTime ScoreDate { get; set; }
       
        public IEnumerable<GetScoresViewModel> GetAllScores()
        {
            Mapper.CreateMap<Score, GetScoresViewModel>();
            return Mapper.Map<IEnumerable<GetScoresViewModel>>(scoreRepository.GetAllScores());
        }
    }
}
