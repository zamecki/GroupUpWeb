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
    public class GroupBusiness : BusinessBase, IGroupBusiness
    {

        public GroupBusiness(IUnityOfWork uow) : base(uow)
        {
        }

        public void Create(Group group)
        {
            Uow.Group.Add(group);
        }

        public void Delete(int groupId)
        {
            Uow.Group.Delete(groupId);
        }

        public void Delete(Group group)
        {
            Uow.Group.Delete(group);
        }

        public bool Exists(int id)
        {
            if (Uow.Group.Where(x => x.GroupID == id).Count() > 0)
                return true;
            else
            {
                ThrowBusinessException("Group not found");
                return false;
            }
        }

        public Group GetGroupFromID(int id)
        {
            return Uow.Group.GetById(id);
        }

        public void Update(Group group)
        {
            var g = Uow.Group.GetById(group.GroupID);
            g = new Group
            {
                Description = group.Description,
                CreatedTime = g.CreatedTime,
                Title = g.Title,
                OwnerId = g.OwnerId,
                LastUpTime = DateTime.Now
            };

        }
    }
}