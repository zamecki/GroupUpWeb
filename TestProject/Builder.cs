using GroupUpWeb.Helpers.Uow;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Builder
    {
        public static User user(IUnityOfWork uow, int index)
        {
            User user = new User(uow);
            user.Name = "TestName " + index.ToString();
            user.LastName = "TestLastName " + index.ToString();
            user.Email = "testEmail@email.com.test " + index.ToString();
            user.Password = "TestHashedPassword " + index.ToString();
            user.SigninDate = DateTime.MinValue;
            user.LastLogin = DateTime.MinValue;
            user.Token = "tokenTest123456789 " + index.ToString();

            return user;
        }
    }
}
