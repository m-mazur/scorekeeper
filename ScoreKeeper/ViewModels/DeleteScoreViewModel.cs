using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreKeeper.Repositories;
using ScoreKeeper.Models;
using AutoMapper;

namespace ScoreKeeper.ViewModels
{
    public class DeleteScoreViewModel
    {
        private ScoreRepository scoreRepository;

        public DeleteScoreViewModel()
        {
            scoreRepository = new ScoreRepository();
        }

        public void DeleteScore(int scoreId)
        {
            scoreRepository.DeleteScore(scoreId);
        }
    }
}