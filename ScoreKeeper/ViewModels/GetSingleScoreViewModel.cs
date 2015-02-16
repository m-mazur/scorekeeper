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
        public int ScoreId { get; set; }
        public int ScorePoints { get; set; }
        public DateTime SoreDate { get; set; }
    }
}