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

namespace ScoreKeeper.Controllers
{
    public class UsersController : ApiController
    {
        private GetAllUsersViewModel getAllUsersViewModel;

        public UsersController() 
        {
            getAllUsersViewModel = new GetAllUsersViewModel();
        }

        //GET api/Users/GetUsers
        public IEnumerable<GetAllUsersViewModel> GetUsers()
        {
            IEnumerable<GetAllUsersViewModel> allUsers = getAllUsersViewModel.GetAllUsers();

            if (allUsers == null) 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return allUsers;
        }
    }
}