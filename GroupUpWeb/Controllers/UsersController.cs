using GroupUpWeb.BusinessInterface;
using GroupUpWeb.Helpers;
using GroupUpWeb.Models;
using GroupUpWeb.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GroupUpWeb.Controllers
{
    public class UsersController : ApiControllerBase
    {

        private IUser UserBusiness;
        private IUserFriends UserFriendsBusiness;

        public UsersController(IUser userBusiness, IUserFriends userFriendsBusiness)
        {
            UserBusiness = userBusiness;
            UserFriendsBusiness = userFriendsBusiness;
        }


        [HttpPost]
        [AllowAnonymous]
        public DtoResultBase CreateUser(User user)
        {
            return Resolve(() =>
            {
                UserBusiness.Create(user);
                UserBusiness.Commit();
                return new DtoResultBase();
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public DtoResultBase DeleteUser(User user)
        {

            return Resolve(() =>
            {
                UserBusiness.Delete();
                UserBusiness.Commit();
                return new DtoResultBase();
            });
        }
        [HttpPost]
        [AllowAnonymous]
        public DtoResultBase AddFriend(User me, User friend)
        {

            return Resolve(() =>
            {
                UserFriendsBusiness.AddFriend(me, friend);
                UserFriendsBusiness.Commit();
                return new DtoResultBase();
            });
        }
    }
}
