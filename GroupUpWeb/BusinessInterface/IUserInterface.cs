using GroupUpWeb.Helpers.Business;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupUpWeb.BusinessInterface
{
    public interface IUserBusiness : ICommitable
    {

        void Login(string fbid);

        bool Exists(string fbid);

        void Add(string fbid);

        void Delete(User user);

        void Delete(int userId);

        void Update(User user);

        void UpdateLogin(string userId);

        User GetUserFromID(string id);
    }
}