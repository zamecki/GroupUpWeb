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
    public class Group: BusinessBase, IGroup
    {
        public int GroupID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpTime { get; set; }

        public Group(IUnityOfWork uow) : base(uow)
        {
        }

        public void Create(Group group, User owner)
        {
            Title = group.Title;
            Description = group.Description;
            OwnerId = owner.UserID;
            Owner = owner;
            CreatedTime = DateTime.Now;
            LastUpTime = DateTime.Now;
            Uow.Group.Add(this);
        }

        public void Delete(Group group)
        {
            Uow.Group.Delete(this);
        }
    }
}