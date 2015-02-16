using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using ScoreKeeper.Models;
using ScoreKeeper.Repositories;
using ScoreKeeper.ViewModels;
using System.Net;
using AutoMapper;

namespace ScoreKeeper.Controllers
{
    public class UsersController : ApiController
    {
        private IUserRepository userRepository;
        public UsersController() 
        {
            userRepository = new UsersRepository();
        }

        //GET api/Users/GetUsers
        public IEnumerable<GetAllUsersViewModel> GetUsers()
        {
            Mapper.CreateMap<User, GetAllUsersViewModel>();
            var allUsers = Mapper.Map<IEnumerable<GetAllUsersViewModel>>(userRepository.GetAllUsers());

            if (allUsers == null) 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return allUsers;
        }
    }
}