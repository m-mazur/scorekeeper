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
        private IUserRepository userRepository;

        public GetAllUsersViewModel()
        {
            this.userRepository = new UsersRepository();
        }

        public IEnumerable<GetAllUsersViewModel> GetAllUsers()
        {
            Mapper.CreateMap<User, GetAllUsersViewModel>();
            return Mapper.Map<IEnumerable<GetAllUsersViewModel>>(userRepository.GetAllUsers());
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}