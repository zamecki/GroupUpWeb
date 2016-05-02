using GroupUpWeb.Helpers.Uow;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.BuilderModels
{
    public class Builder
    {
        public static User user(IUnityOfWork Uow)
        {
            User user = new User(Uow);
            user.Name = "NameGeneratedUser1";
            user.LastName = "LastNameGeneratedUser1";
            user.Email = "EmailGeneratedUser1@email.com";
            user.Password = "PasswordGeneratedUser1";
            user.Token = "HashKeyGeneratedUser1";
            user.SigninDate = DateTime.Parse("2009-12-05");
            user.LastLogin = DateTime.Parse("2016-02-05");
            return user;
        }
    }
}
