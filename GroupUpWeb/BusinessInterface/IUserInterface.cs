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

        string Login(string email, string password);

        bool Exists(string token);

        void Add(User user);

        void Delete(User user);

        void Delete(int userId);

        void Update(User user);

        string UpdateLogin(string email, string password);

        User GetUserFromID(int id);

        List<User> SearchUser(string searchText);
    }
}