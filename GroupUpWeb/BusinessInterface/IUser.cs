using GroupUpWeb.Helpers.Business;
using GroupUpWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupUpWeb.BusinessInterface
{
    public interface IUser: ICommitable
    {
        void Create(User user);
        void Delete();
        void EditName(string name);
        void EditLastName(string lastName);
        void EditEmail(string email);
        void EditPassword(string password);
        void GenerateToken();
        string GetToken();
        void UpdateLoginDate();
    }
}