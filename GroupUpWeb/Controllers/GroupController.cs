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
    public class GroupController : ApiControllerBase
    {
        private IGroupBusiness GroupBusiness;

        public GroupController(IGroupBusiness groupBusiness)
        {
            GroupBusiness = groupBusiness;
        }

        [HttpPost]
        [AllowAnonymous]
        public DtoResultBase Create(Group group)
        {
            return Resolve(() =>
            {
                GroupBusiness.Create(group);
                return new DtoResultBase();
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public DtoResultBase Delete(Group group)
        {
            return Resolve(() =>
            {
                GroupBusiness.Delete(group);
                return new DtoResultBase();
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public DtoResultBase Delete(int groupId)
        {
            return Resolve(() =>
            {
                GroupBusiness.Delete(groupId);
                return new DtoResultBase();
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public DtoResult<bool> Exist(int groupId)
        {
            return Resolve<DtoResult<bool>>(() =>
            {
                var result = new DtoResult<bool>();

                result.Result = GroupBusiness.Exists(groupId);

                return result;
            });

        }

    }
}