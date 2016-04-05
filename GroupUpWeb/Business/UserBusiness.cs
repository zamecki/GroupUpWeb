using GroupUpWeb.BusinessInterface;
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
        public void Add(string fbid)
        {
            Uow.User.Add(new User
            {
                FbID = fbid,
                SinginDate = DateTime.Now,
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
            var u = Uow.User.Where(t => t.FbID == user.FbID).FirstOrDefault();
            u = new User
            {
                FbID = user.FbID,
                SinginDate = user.SinginDate,
                LastLogin = DateTime.Now
            };
        }

        public void UpdateLogin(string fbid)
        {
            var u = Uow.User.Where(t => t.FbID == fbid).FirstOrDefault();
            u.LastLogin = DateTime.Now;
        }

        public bool Exists(string fbid)
        {

            var user = Uow.User.Where(u => u.FbID == fbid).FirstOrDefault();

            if (user != null)
                return true;
            else return false;
            //if (Uow.User.GetAll().Count() == 0)
            //    return false;
            //if (Uow.User.Where(user => user.FbID.Equals(fbid)).Count() > 0)
            //    return true;
            //else return false;
        }

        public void Login(string fbid)
        {
            UpdateLogin(fbid);
        }
        public User GetUserFromID(string id)
        {
            return Uow.User.Where(u => u.FbID == id).FirstOrDefault();
        }
    }
}