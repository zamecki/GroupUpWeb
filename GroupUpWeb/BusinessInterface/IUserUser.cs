using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupUpWeb.BusinessInterface
{
    interface IUserUser
    {
        void AddFriend(User userOne, User userTwo);

        void Delete();
    }
}
