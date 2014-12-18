using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ScoreKeeper.Models;
using ScoreKeeper.Repositories;

namespace ScoreKeeper.Controllers
{
    public class UsersController : ApiController
    {
        private UsersRepository userRepository = new UsersRepository();

        //GET api/Users
        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAllUsers();
        }
    }
}