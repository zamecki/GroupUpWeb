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
        public DtoResultBase Login(string email, string password)
        {
            return Resolve(() =>
            {
                var result = new DtoResultBase();

                bool exist = false;
                exist = UserBusiness.Exists(email);
                if (exist)
                {
                    result.Message = UserBusiness.Login(email, password);
                    result.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else {
                    result.Message = "NotFound";
                    result.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
                return result;
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public DtoResult<bool> Exist(string fbid)
        {
            return Resolve<DtoResult<bool>>(() =>
            {
                var result = new DtoResult<bool>();

                result.Result = UserBusiness.Exists(fbid);

                return result;
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
        public DtoResultBase Test()
        {
            return Resolve<DtoResultBase>(() =>
            {
                return new DtoResultBase();
            });
        }
    }
}
