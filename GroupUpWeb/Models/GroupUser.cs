using GroupUpWeb.BusinessInterface;
using GroupUpWeb.Helpers.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GroupUpWeb.Helpers.Uow;

namespace GroupUpWeb.Models
{
    public class GroupUser: BusinessBase, IGroupUsers
    {
        public int GroupUserID { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }

        public GroupUser(IUnityOfWork uow) : base(uow)
        {
        }

        public void AddUser(Group group, User user)
        {
            GroupId = group.GroupID;
            UserId = user.UserID;
            Group = group;
            User = user;
            Uow.GroupUser.Add(this);
        }
    }
}