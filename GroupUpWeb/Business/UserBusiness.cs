using GroupUpWeb.BusinessInterface;
using GroupUpWeb.Helpers;
using GroupUpWeb.Helpers.Business;
using GroupUpWeb.Helpers.Uow;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupUpWeb.Business
{
    public class UserBusiness : BusinessBase, IUserBusiness
    {
        public UserBusiness(IUnityOfWork uow) : base(uow)
        {
        }

        public void Add(User user)
        {
            Uow.User.Add(new User
            {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                LastName = user.LastName,
                Token = TokenGenerator.Token(),
                SigninDate = DateTime.Now,
                LastLogin = DateTime.Now
            });
        }

        public void Delete(User user)
        {
            Uow.User.Delete(user);
        }
        public void Delete(int userId)
        {
            Uow.User.Delete(userId);
        }
        public void Update(User user)
        {
            var u = Uow.User.Where(t => t.Token == user.Token).FirstOrDefault();
            u.LastLogin = DateTime.Now;
        }

        public string UpdateLogin(string email, string password)
        {
            var u = Uow.User.Where(t => t.Email == email).FirstOrDefault();
            u.LastLogin = DateTime.Now;
            u.Token = TokenGenerator.Token();
            return u.Token;
        }

        public bool Exists(string email)
        {
            var user = Uow.User.Where(u => u.Email == email).FirstOrDefault();

            if (user != null)
                return true;
            else return false;
        }

        public string Login(string email, string password)
        {
            return UpdateLogin(email, password);
        }
        public User GetUserFromID(int id)
        {
            return Uow.User.Where(u => u.UserID == id).FirstOrDefault();
        }

        public List<User> SearchUser(string searchText)
        {
            return Uow.User.Where(u => u.Email.Contains(searchText)).ToList();
        }
    }
}