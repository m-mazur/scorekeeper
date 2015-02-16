using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ScoreKeeper.Models;
using ScoreKeeper.ViewModels;

namespace ScoreKeeper
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            ConfigureAllScoresViewModel();
            ConfigureAllUsersViewModel();
            ConfigureLatestScoreViewModel();
            ConfigureSingleScoreViewModel();
        }
        private static void ConfigureAllScoresViewModel()
        {
            Mapper.CreateMap<Score, GetAllScoresViewModel>();
        }

        private static void ConfigureAllUsersViewModel()
        {
            Mapper.CreateMap<User, GetAllUsersViewModel>();
        }

        private static void ConfigureLatestScoreViewModel()
        {
            Mapper.CreateMap<Score, GetLatestScoreViewModel>();
        }

        private static void ConfigureSingleScoreViewModel()
        {
            Mapper.CreateMap<Score, GetSingleScoreViewModel>();
        }
    }
}