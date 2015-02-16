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
        public string UserName { get; set; }
        public int ScoreId { get; set; }
        public int ScorePoints { get; set; }
        public DateTime ScoreDate { get; set; }
    }
}