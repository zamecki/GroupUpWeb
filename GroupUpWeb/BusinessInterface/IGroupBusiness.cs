using GroupUpWeb.Helpers.Business;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupUpWeb.BusinessInterface
{
    public interface IGroupBusiness : ICommitable
    {
        bool Exists(int id);

        void Create(Group group);

        void Delete(Group group);

        void Delete(int groupId);

        void Update(Group group);

        Group GetGroupFromID(int id);
    }
}