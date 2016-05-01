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
        private IGroup GroupBusiness;

        public GroupController(IGroup groupBusiness)
        {
            GroupBusiness = groupBusiness;
        }

        [HttpPost]
        [AllowAnonymous]
        public DtoResultBase Create(Group group, User owner)
        {
            return Resolve(() =>
            {
                GroupBusiness.Create(group, owner);
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

    }
}