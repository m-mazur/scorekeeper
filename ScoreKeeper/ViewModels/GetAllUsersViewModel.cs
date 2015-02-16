using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreKeeper.Models;
using ScoreKeeper.Repositories;
using AutoMapper;

namespace ScoreKeeper.ViewModels
{
    public class GetAllUsersViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}