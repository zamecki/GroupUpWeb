using GroupUpWeb.Helpers.Business;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupUpWeb.BusinessInterface
{
    public interface IGroupUsers: ICommitable
    {
        void AddUser(Group group, User user);
    }
}
