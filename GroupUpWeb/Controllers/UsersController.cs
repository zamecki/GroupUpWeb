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
        private IUserBusiness UserBusiness { get; set; }

        public UsersController(IUserBusiness userBusiness)
        {
            UserBusiness = userBusiness;
        }

        [HttpGet]
        [AllowAnonymous]
        public DtoResultBase Login(string fbid)
        {

            return Resolve(() =>
            {
                if (UserBusiness.Exists(fbid))
                    UserBusiness.Login(fbid);
                else
                {
                    UserBusiness.Add(fbid);
                }
                UserBusiness.Commit();
                return new DtoResultBase();
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public DtoResultBase DeleteAccount(User user)
        {

            return Resolve(() =>
            {
                UserBusiness.Delete(user);
                UserBusiness.Commit();
                return new DtoResultBase();
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public DtoResult<bool> Exist(string fbId)
        {
            return Resolve<DtoResult<bool>>(() =>
            {
                var result = new DtoResult<bool>();

                result.Result = UserBusiness.Exists(fbId);

                return result;
            });
        }
        [HttpGet]
        [AllowAnonymous]
        public DtoResultBase Test()
        {
            return Resolve<DtoResultBase>(() =>
            {
                return new DtoResultBase();
            });
        }
    }
}
