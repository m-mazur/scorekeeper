using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreKeeper.Repositories;
using ScoreKeeper.Models;
using AutoMapper;

namespace ScoreKeeper.ViewModels
{
    public class AddScoreViewModel
    {
        private ScoreRepository scoreRepository;

        public AddScoreViewModel()
        {
            scoreRepository = new ScoreRepository();
        }

        public void AddScore(AddScoreViewModel scoreViewModel)
        {
            Mapper.CreateMap<AddScoreViewModel, Score>();
            scoreRepository.AddScore(Mapper.Map<Score>(scoreViewModel));
        }

        public string ScorePoints { get; set; }
        public int UserId { get; set; }
    }
}